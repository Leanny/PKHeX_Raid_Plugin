/*
 MIT License

Copyright (c) 2019 Leanny

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/

using PKHeX.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;

namespace PKHeX_Raid_Plugin
{
    public partial class DenIVs : Form
    {
        private DenManager dm;
        static readonly int[] min_stars = { 0, 0, 0, 0, 1, 1, 2, 2, 2 };
        static readonly int[] max_stars = { 0, 1, 1, 2, 2, 2, 3, 3, 4 };
        public DenIVs(int idx, DenManager dm)
        {
            InitializeComponent();
            this.dm = dm;
            Den den = dm.GetDen(idx);
            seedBox.Text = den.seed.ToString("X");
            denBox.SelectedIndex = idx;

        }

        private ulong advance(ulong start, uint frames)
        {
            return start + frames * XOROSHIRO.XOROSHIRO_CONST;
        }

        private void denBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Den den = dm.GetDen(denBox.SelectedIndex);
            this.seedBox.Text = den.seed.ToString("X");
            this.speciesList.Items.Clear();
            var s = GameInfo.Strings;
            for (int stars = min_stars[dm.badges]; stars <= max_stars[dm.badges]; stars++)
            {
                var entries = dm.GetAllEntriesWithStarcount(den, stars);
                foreach (var entry in entries)
                {
                    ComboboxItem item = new ComboboxItem();
                    item.Text = string.Format("{0}\u2605 {1}", stars + 1, s.Species[entry.Species]);
                    item.Value = entry;
                    this.speciesList.Items.Add(item);
                }
            }
            speciesList.SelectedIndex = 0;
        }

        public class ComboboxItem
        {
            public string Text { get; set; }
            public object Value { get; set; }

            public override string ToString()
            {
                return Text;
            }
        }

        private void generateData_Click(object sender, EventArgs e)
        {
            var genders = new string[] { "Male", "Female", "Genderless" };
            var shinytype = new string[] { "No", "Star", "Square" };
            ulong start_seed = ulong.Parse(seedBox.Text, System.Globalization.NumberStyles.HexNumber);
            uint start_frame = uint.Parse(startFrame.Text);
            uint end_frame = uint.Parse(endFrame.Text);
            ulong current_seed = advance(start_seed, start_frame);
            var s = GameInfo.Strings;
            Entry pkmn = (Entry)((ComboboxItem)speciesList.SelectedItem).Value;
            raidContent.Rows.Clear();
            List<DataGridViewRow> rows = new List<DataGridViewRow>();
            ((ISupportInitialize)raidContent).BeginInit();
            for (uint current_frame = start_frame; current_frame <= end_frame; current_frame++, current_seed += XOROSHIRO.XOROSHIRO_CONST)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(raidContent);

                Pkmn res = dm.GetPkmnFromDetails(current_seed, pkmn);
                row.Cells[0].Value = current_frame.ToString();
                row.Cells[1].Value = res.ivs[0].ToString();
                row.Cells[2].Value = res.ivs[1].ToString();
                row.Cells[3].Value = res.ivs[2].ToString();
                row.Cells[4].Value = res.ivs[3].ToString();
                row.Cells[5].Value = res.ivs[4].ToString();
                row.Cells[6].Value = res.ivs[5].ToString();
                row.Cells[7].Value = s.Natures[res.nature];
                row.Cells[8].Value = s.Ability[res.ability];
                row.Cells[9].Value = genders[res.gender];
                row.Cells[10].Value = shinytype[res.shinytype];
                row.Cells[11].Value = current_seed.ToString("X");
                rows.Add(row);
            }
            raidContent.Rows.AddRange(rows.ToArray());
            // Double buffering can make DGV slow in remote desktop
            if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            {
                Type dgvType = raidContent.GetType();
                PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
                pi.SetValue(raidContent, true, null);
            }
            ((ISupportInitialize)raidContent).EndInit();
            //raidContent
        }

        private void applyFilter_Click(object sender, EventArgs e)
        {
            DataGridViewRow[] theRows = new DataGridViewRow[raidContent.Rows.Count];
            raidContent.Rows.CopyTo(theRows, 0);
            raidContent.Rows.Clear();
            for (int loop = 0; loop < theRows.Length; loop++)
            {
                int hp = int.Parse((string)theRows[loop].Cells[1].Value);
                int atk = int.Parse((string)theRows[loop].Cells[2].Value);
                int def = int.Parse((string)theRows[loop].Cells[3].Value);
                int spa = int.Parse((string)theRows[loop].Cells[4].Value);
                int spd = int.Parse((string)theRows[loop].Cells[5].Value);
                int spe = int.Parse((string)theRows[loop].Cells[6].Value);
                string nature = (string)theRows[loop].Cells[7].Value;
                string ability = (string)theRows[loop].Cells[8].Value;
                string gender = (string)theRows[loop].Cells[9].Value;
                string shiny = (string)theRows[loop].Cells[10].Value;
                if (hp >= minHP.Value && hp <= maxHP.Value &&
                    atk >= minAtk.Value && atk <= maxAtk.Value &&
                    def >= minDef.Value && def <= maxDef.Value &&
                    spa >= minSpa.Value && spa <= maxSpa.Value &&
                    spd >= minSpd.Value && spd <= maxSpd.Value &&
                    spe >= MinSpe.Value && spe <= maxSpe.Value &&
                    (natureBox.SelectedIndex == 0 || natureBox.Text == nature) &&
                    (abilityBox.SelectedIndex == 0 || abilityBox.Text == ability) &&
                    (genderBox.SelectedIndex == 0 || genderBox.Text == gender) &&
                    (shinyBox.SelectedIndex == 0 || (shinyBox.SelectedIndex == 1 && shiny != "No" || shinyBox.Text == shiny)))
                {
                    theRows[loop].Visible = true;
                }
                else
                {
                    theRows[loop].Visible = false;
                }
            }
            raidContent.Rows.AddRange(theRows);
        }

        private void speciesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var s = GameInfo.Strings;
            Entry pkmn = (Entry)((ComboboxItem)speciesList.SelectedItem).Value;
            int[] abilities = PersonalTable.SWSH.GetAbilities(pkmn.Species, pkmn.AltForm);
            abilityBox.Items.Clear();
            abilityBox.Items.Add("Any");
            foreach (int ability in abilities)
            {
                ComboboxItem ab = new ComboboxItem();
                ab.Text = string.Format(s.Ability[ability]);
                ab.Value = ability;
                abilityBox.Items.Add(ab);
            }
            genderBox.Items.Clear();
            int gt = PersonalTable.SWSH[pkmn.Species].Gender;
            ComboboxItem genderless = new ComboboxItem();
            genderless.Text = string.Format("Genderless");
            genderless.Value = 2;
            ComboboxItem female = new ComboboxItem();
            female.Text = string.Format("Female");
            female.Value = 1;
            ComboboxItem male = new ComboboxItem();
            male.Text = string.Format("Male");
            male.Value = 0;
            ComboboxItem any = new ComboboxItem();
            any.Text = string.Format("Any");
            any.Value = -1;
            switch (gt)
            {
                case 255:
                    genderBox.Items.Add(genderless); // Genderless
                    break;
                case 254:
                    genderBox.Items.Add(female); // Female-Only
                    break;
                case 0:
                    genderBox.Items.Add(male);// Male-Only
                    break;
                default:
                    genderBox.Items.Add(any);
                    genderBox.Items.Add(female);
                    genderBox.Items.Add(male);
                    break;
            }

            abilityBox.SelectedIndex = 0;
            genderBox.SelectedIndex = 0;
        }

        private void seedBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f') || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void isNumberPressed(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void resetFilter_Click(object sender, EventArgs e)
        {
            DataGridViewRow[] theRows = new DataGridViewRow[raidContent.Rows.Count];
            raidContent.Rows.CopyTo(theRows, 0);
            raidContent.Rows.Clear();
            for (int loop = 0; loop < theRows.Length; loop++)
            {
                theRows[loop].Visible = true;
            }
            raidContent.Rows.AddRange(theRows);
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This might take a long time. Are you sure you want to start the search?", "Start a search?",  MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                ulong start_seed = ulong.Parse(seedBox.Text, System.Globalization.NumberStyles.HexNumber);
                uint start_frame = uint.Parse(startFrame.Text);
                uint end_frame = uint.Parse(endFrame.Text);
                ulong current_seed = advance(start_seed, start_frame);
                Entry pkmn = (Entry)((ComboboxItem)speciesList.SelectedItem).Value;
                raidContent.Rows.Clear();
                var genders = new string[] { "Male", "Female", "Genderless" };
                var shinytype = new string[] { "No", "Star", "Square" };
                var s = GameInfo.Strings;
                ((ISupportInitialize)raidContent).BeginInit();
                for (uint current_frame = start_frame; ; current_frame++, current_seed += XOROSHIRO.XOROSHIRO_CONST)
                {
                    Pkmn res = dm.GetPkmnFromDetails(current_seed, pkmn);
                    if (res.ivs[0] >= minHP.Value && res.ivs[0] <= maxHP.Value &&
                        res.ivs[1] >= minAtk.Value && res.ivs[1] <= maxAtk.Value &&
                        res.ivs[2] >= minDef.Value && res.ivs[2] <= maxDef.Value &&
                        res.ivs[3] >= minSpa.Value && res.ivs[3] <= maxSpa.Value &&
                        res.ivs[4] >= minSpd.Value && res.ivs[4] <= maxSpd.Value &&
                        res.ivs[5] >= MinSpe.Value && res.ivs[5] <= maxSpe.Value &&
                        (natureBox.SelectedIndex == 0 || natureBox.SelectedIndex - 1 == res.nature) &&
                        (abilityBox.SelectedIndex == 0 || (int)((ComboboxItem)abilityBox.SelectedItem).Value == res.ability) &&
                        (genderBox.SelectedIndex == 0 || (int)((ComboboxItem)genderBox.SelectedItem).Value == res.gender) &&
                        (shinyBox.SelectedIndex == 0 || (shinyBox.SelectedIndex == 1 && res.shinytype > 0 || shinyBox.SelectedIndex - 2 == res.shinytype)))
                    {
                        DataGridViewRow row = new DataGridViewRow();
                        row.CreateCells(raidContent);
                        row.Cells[0].Value = current_frame.ToString();
                        row.Cells[1].Value = res.ivs[0].ToString();
                        row.Cells[2].Value = res.ivs[1].ToString();
                        row.Cells[3].Value = res.ivs[2].ToString();
                        row.Cells[4].Value = res.ivs[3].ToString();
                        row.Cells[5].Value = res.ivs[4].ToString();
                        row.Cells[6].Value = res.ivs[5].ToString();
                        row.Cells[7].Value = s.Natures[res.nature];
                        row.Cells[8].Value = s.Ability[res.ability];
                        row.Cells[9].Value = genders[res.gender];
                        row.Cells[10].Value = shinytype[res.shinytype];
                        row.Cells[11].Value = current_seed.ToString("X");
                        raidContent.Rows.Add(row);
                        break;
                    }
                }
            ((ISupportInitialize)raidContent).EndInit();
            }

        }
    }
}
