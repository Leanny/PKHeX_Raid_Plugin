using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

using PKHeX.Core;

namespace PKHeX_Raid_Plugin
{
    public partial class DenIVs : Form
    {
        private readonly RaidManager Raids;
        private static readonly int[] min_stars = { 0, 0, 0, 0, 1, 1, 2, 2, 2, 0 };
        private static readonly int[] max_stars = { 0, 1, 1, 2, 2, 2, 3, 3, 4, 4 };

        private static readonly ComboboxItem genderless = new ComboboxItem("Genderless", 2);
        private static readonly ComboboxItem female = new ComboboxItem("Female", 1);
        private static readonly ComboboxItem male = new ComboboxItem("Male", 0);
        private static readonly ComboboxItem any = new ComboboxItem("Any", -1);

        private static readonly string[] genders = { "Male", "Female", "Genderless" };
        private static readonly string[] shinytype = { "No", "Star", "Square" };

        public DenIVs(int idx, RaidManager raids)
        {
            InitializeComponent();
            Raids = raids;
            var param = raids[idx];
            seedBox.Text = $"{param.Seed:X16}";
            denBox.SelectedIndex = idx;
            CenterToParent();
        }

        private static ulong Advance(ulong start, uint frames)
        {
            return start + (frames * XOROSHIRO.XOROSHIRO_CONST);
        }

        private void DenBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            RaidParameters raidParameters = Raids[denBox.SelectedIndex];
            seedBox.Text = raidParameters.Seed.ToString("X");
            speciesList.Items.Clear();
            var s = GameInfo.Strings;
            for (int stars = min_stars[Raids.BadgeCount]; stars <= max_stars[Raids.BadgeCount]; stars++)
            {
                var entries = Raids.GetAllTemplatesWithStarCount(raidParameters, stars);
                foreach (var entry in entries)
                {
                    ComboboxItem item = new ComboboxItem($"{stars + 1}\u2605 {s.Species[entry.Species]}", entry);
                    speciesList.Items.Add(item);
                }
            }
            speciesList.SelectedIndex = 0;
        }

        private void GenerateData_Click(object sender, EventArgs e)
        {
            ulong start_seed = ulong.Parse(seedBox.Text, System.Globalization.NumberStyles.HexNumber);
            uint start_frame = uint.Parse(startFrame.Text);
            uint end_frame = uint.Parse(endFrame.Text);
            ulong current_seed = Advance(start_seed, start_frame);
            var s = GameInfo.Strings;
            RaidTemplate pkmn = (RaidTemplate)((ComboboxItem)speciesList.SelectedItem).Value;
            raidContent.Rows.Clear();
            var rows = new List<DataGridViewRow>();
            ((ISupportInitialize)raidContent).BeginInit();
            for (uint current_frame = start_frame; current_frame <= end_frame; current_frame++, current_seed += XOROSHIRO.XOROSHIRO_CONST)
            {
                RaidPKM res = pkmn.ConvertToPKM(current_seed, Raids.TID, Raids.SID);
                var row = CreateRaidRow(current_frame, res, s, current_seed);
                rows.Add(row);
            }
            raidContent.Rows.AddRange(rows.ToArray());
            // Double buffering can make DGV slow in remote desktop
            if (!SystemInformation.TerminalServerSession)
                raidContent.DoubleBuffered(true);
            ((ISupportInitialize)raidContent).EndInit();
            //raidContent
        }

        private void ApplyFilter_Click(object sender, EventArgs e)
        {
            var rows = new DataGridViewRow[raidContent.Rows.Count];
            raidContent.Rows.CopyTo(rows, 0);
            raidContent.Rows.Clear();
            foreach (var row in rows)
                row.Visible = GetIsRowVisible(row);
            raidContent.Rows.AddRange(rows);
        }

        private bool IsRowVisible(RaidPKM res)
        {
            if (res.IVs[0] < minHP.Value || res.IVs[0] > maxHP.Value)
                return false;
            if (res.IVs[1] < minAtk.Value || res.IVs[1] > maxAtk.Value)
                return false;
            if (res.IVs[2] < minDef.Value || res.IVs[2] > maxDef.Value)
                return false;
            if (res.IVs[3] < minSpa.Value || res.IVs[3] > maxSpa.Value)
                return false;
            if (res.IVs[4] < minSpd.Value || res.IVs[4] > maxSpd.Value)
                return false;
            if (res.IVs[5] < MinSpe.Value || res.IVs[5] > maxSpe.Value)
                return false;
            if (natureBox.SelectedIndex != 0 && natureBox.SelectedIndex - 1 != res.Nature)
                return false;
            if (abilityBox.SelectedIndex != 0 && (int)((ComboboxItem)abilityBox.SelectedItem).Value != res.Ability)
                return false;
            if (genderBox.SelectedIndex != 0 && (int)((ComboboxItem)genderBox.SelectedItem).Value != res.Gender)
                return false;

            return (shinyBox.SelectedIndex == 1 && res.ShinyType > 0) || shinyBox.SelectedIndex - 2 == res.ShinyType || shinyBox.SelectedIndex == 0;
        }

        private bool GetIsRowVisible(DataGridViewRow row)
        {
            int hp = int.Parse((string) row.Cells[1].Value);
            if (hp < minHP.Value || hp > maxHP.Value)
                return false;

            int atk = int.Parse((string)row.Cells[2].Value);
            if (atk < minAtk.Value || atk > maxAtk.Value)
                return false;

            int def = int.Parse((string)row.Cells[3].Value);
            if (def < minDef.Value || def > maxDef.Value)
                return false;

            int spa = int.Parse((string)row.Cells[4].Value);
            if (spa < minSpa.Value || spa > maxSpa.Value)
                return false;

            int spd = int.Parse((string)row.Cells[5].Value);
            if (spd < minSpd.Value || spd > maxSpd.Value)
                return false;

            int spe = int.Parse((string)row.Cells[6].Value);
            if (spe < MinSpe.Value || spe > maxSpe.Value)
                return false;

            if (natureBox.SelectedIndex != 0 && natureBox.Text != (string)row.Cells[7].Value)
                return false;

            if (abilityBox.SelectedIndex != 0 && abilityBox.Text != (string)row.Cells[8].Value)
                return false;

            if (genderBox.SelectedIndex != 0 && genderBox.Text != (string)row.Cells[9].Value)
                return false;

            string shiny = (string)row.Cells[10].Value;
            return (shinyBox.SelectedIndex == 1 && shiny != "No") || shinyBox.Text == shiny || shinyBox.SelectedIndex == 0;
        }

        private void SpeciesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pkm = (RaidTemplate)((ComboboxItem)speciesList.SelectedItem).Value;
            var abilities = PersonalTable.SWSH.GetAbilities(pkm.Species, pkm.AltForm);
            PopulateAbilityList(abilities, pkm.Ability);
            PopulateGenderList(PersonalTable.SWSH[pkm.Species].Gender);

            abilityBox.SelectedIndex = 0;
            genderBox.SelectedIndex = 0;
        }

        private void PopulateAbilityList(int[] abilities, int a)
        {
            abilityBox.Items.Clear();
            abilityBox.Items.Add("Any");
            var s = GameInfo.Strings;
            foreach (int ability in abilities)
            {
                if (a == 3 && abilityBox.Items.Count == 3)
                    break;

                var ab = new ComboboxItem(s.Ability[ability], ability);
                abilityBox.Items.Add(ab);
            }
        }

        private void PopulateGenderList(int gt)
        {
            genderBox.Items.Clear();
            switch (gt)
            {
                case 255:
                    genderBox.Items.Add(genderless); // Genderless
                    break;
                case 254:
                    genderBox.Items.Add(female); // Female-Only
                    break;
                case 0:
                    genderBox.Items.Add(male); // Male-Only
                    break;
                default:
                    genderBox.Items.Add(any);
                    genderBox.Items.Add(female);
                    genderBox.Items.Add(male);
                    break;
            }
        }

        private void SeedBox_KeyPress(object sender, KeyPressEventArgs e) => e.Handled = !Util.IsHexOrControl(e.KeyChar);
        private void IsNumberPressed(object sender, KeyPressEventArgs e) => e.Handled = !Util.IsDigitOrControl(e.KeyChar);

        private void ResetFilter_Click(object sender, EventArgs e)
        {
            var rows = new DataGridViewRow[raidContent.Rows.Count];
            raidContent.Rows.CopyTo(rows, 0);
            raidContent.Rows.Clear();
            foreach (var row in rows)
                row.Visible = true;
            raidContent.Rows.AddRange(rows);
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            var result = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "This might take a long time. Are you sure you want to start the search?");
            if (result != DialogResult.Yes)
                return;

            ulong start_seed = ulong.Parse(seedBox.Text, System.Globalization.NumberStyles.HexNumber);
            uint start_frame = uint.Parse(startFrame.Text);
            // uint end_frame = uint.Parse(endFrame.Text);
            ulong current_seed = Advance(start_seed, start_frame);
            var template = (RaidTemplate)((ComboboxItem)speciesList.SelectedItem).Value;
            var s = GameInfo.Strings;

            ((ISupportInitialize)raidContent).BeginInit();
            raidContent.Rows.Clear();
            for (uint current_frame = start_frame; ; current_frame++, current_seed += XOROSHIRO.XOROSHIRO_CONST)
            {
                var pkm = template.ConvertToPKM(current_seed, Raids.TID, Raids.SID);
                if (!IsRowVisible(pkm))
                    continue;
                var row = CreateRaidRow(current_frame, pkm, s, current_seed);
                raidContent.Rows.Add(row);
                break;
            }
            ((ISupportInitialize)raidContent).EndInit();
        }

        private DataGridViewRow CreateRaidRow(uint current_frame, RaidPKM res, GameStrings s, ulong current_seed)
        {
            var row = new DataGridViewRow();
            row.CreateCells(raidContent);
            row.Cells[0].Value = current_frame.ToString();
            row.Cells[1].Value = $"{res.IVs[0]:00}";
            row.Cells[2].Value = $"{res.IVs[1]:00}";
            row.Cells[3].Value = $"{res.IVs[2]:00}";
            row.Cells[4].Value = $"{res.IVs[3]:00}";
            row.Cells[5].Value = $"{res.IVs[4]:00}";
            row.Cells[6].Value = $"{res.IVs[5]:00}";
            row.Cells[7].Value = s.Natures[res.Nature];
            row.Cells[8].Value = s.Ability[res.Ability];
            row.Cells[9].Value = genders[res.Gender];
            row.Cells[10].Value = shinytype[res.ShinyType];
            row.Cells[11].Value = $"{current_seed:X16}";
            return row;
        }
    }
}
