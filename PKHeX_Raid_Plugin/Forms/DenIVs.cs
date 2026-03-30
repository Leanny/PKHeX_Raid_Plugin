using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

using PKHeX.Core;

namespace PKHeX_Raid_Plugin
{
    public partial class DenIVs : Form
    {
        private readonly RaidManager Raids;
        private static readonly int[] min_stars = [0, 0, 0, 0, 1, 1, 2, 2, 2, 0];
        private static readonly int[] max_stars = [0, 1, 1, 2, 2, 2, 3, 3, 4, 4];

        private static readonly ComboboxItem genderless = new("Genderless", 2);
        private static readonly ComboboxItem female = new("Female", 1);
        private static readonly ComboboxItem male = new("Male", 0);
        private static readonly ComboboxItem any = new("Any", -1);

        private static readonly string[] genders = { "Male", "Female", "Genderless" };
        private static readonly string[] shinytype = { "No", "Star", "Square" };
        private static readonly Dictionary<string, int> natureIdx = [];

        private CancellationTokenSource cts = new();
        private ContextMenuStrip seedCellMenu;
        public string SelectedSeed { get; private set; }
        public int SelectedDenIndex { get; private set; }

        public DenIVs(int idx, RaidManager raids)
        {
            InitializeComponent();
            var gameStrings = GameInfo.Strings;
            Raids = raids;
            var param = raids[idx];
            seedBox.Text = $"{param.Seed:X16}";
            denBox.SelectedIndex = idx;
            natureBox.Items.Clear();
            natureBox.Items.Add("Any");
            natureBox.Items.AddRange(gameStrings.natures);

            for (int i = 0; i < gameStrings.natures.Length; i++)
            {
                natureIdx[gameStrings.natures[i]] = i + 1;
            }

            natureBox.MaxDropDownItems = gameStrings.natures.Length;
            natureBox.DefaultValue = "Any";
            natureBox.DisplayMember = "Value";
            natureBox.SetItemChecked(0, true);
            natureBox.DropDownClosed += (sender, e) => Focus();
            shinyBox.SelectedIndex = 0;
            CenterToParent();
        }

        private void DenIVs_Load(object sender, EventArgs e)
        {
            seedCellMenu = new ContextMenuStrip();
            seedCellMenu.Items.Add("Copy To Clipboard", null, CopyValueToClipboard_Click);
            seedCellMenu.Items.Add("Set to current seed", null, SetSeedValue);
        }

        private static ulong Advance(ulong start, uint frames)
        {
            return start + (frames * Xoroshiro128Plus.XOROSHIRO_CONST);
        }

        private void DenBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SelectedDenIndex = denBox.SelectedIndex;
            RaidParameters raidParameters = Raids[denBox.SelectedIndex];
            seedBox.Text = raidParameters.Seed.ToString("X");
            speciesList.Items.Clear();
            var s = GameInfo.Strings;
            if (raidParameters.IsCrystal)
            {
                var entries = Raids.GetAllTemplatesWithStarCount(raidParameters, 0);
                foreach (var entry in entries)
                {
                    ComboboxItem item = new($"{entry.MinRank + 1}\u2605 {s.Species[entry.Species]}", entry);
                    speciesList.Items.Add(item);
                }
            }
            else
            {
                for (int stars = min_stars[Raids.BadgeCount]; stars <= max_stars[Raids.BadgeCount]; stars++)
                {
                    var entries = Raids.GetAllTemplatesWithStarCount(raidParameters, stars);
                    foreach (var entry in entries)
                    {
                        ComboboxItem item = new($"{stars + 1}\u2605 {s.Species[entry.Species]}", entry);
                        speciesList.Items.Add(item);
                    }
                }
            }
            speciesList.SelectedIndex = 0;
        }

        private void GenerateData_Click(object sender, EventArgs e)
        {
            ulong start_seed = ulong.Parse(seedBox.Text, System.Globalization.NumberStyles.HexNumber);
            if (!uint.TryParse(startFrame.Text, out uint start_frame))
            {
                start_frame = uint.MaxValue;
            }
            startFrame.Text = start_frame.ToString();
            if (!uint.TryParse(endFrame.Text, out uint end_frame))
            {
                end_frame = uint.MaxValue;
            }
            endFrame.Text = end_frame.ToString();
            ulong current_seed = Advance(start_seed, start_frame);
            var s = GameInfo.Strings;
            if (speciesList.SelectedItem is not ComboboxItem { Value: RaidTemplate pkmn })
                return;
            raidContent.Rows.Clear();
            var rows = new List<DataGridViewRow>();
            ((ISupportInitialize)raidContent).BeginInit();
            for (uint current_frame = start_frame; current_frame <= start_frame + end_frame; current_frame++, current_seed += Xoroshiro128Plus.XOROSHIRO_CONST)
            {
                RaidPKM res = pkmn.ConvertToPKM(current_seed, Raids.TID, Raids.SID);
                var row = CreateRaidRow(current_frame, res, s, current_seed);
                rows.Add(row);
            }
            raidContent.Rows.AddRange([.. rows]);
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
            if (!natureBox.GetItemChecked(0) && !natureBox.GetItemChecked(res.Nature + 1))
                return false;
            if (abilityBox.SelectedIndex != 0)
            {
                var abilityItem = abilityBox.SelectedItem as ComboboxItem;
                if (abilityItem?.Value is not int ability || ability != res.Ability)
                    return false;
            }

            if (genderBox.SelectedIndex != 0)
            {
                var genderItem = genderBox.SelectedItem as ComboboxItem;
                if (genderItem?.Value is not int gender || gender != res.Gender)
                    return false;
            }

            return (shinyBox.SelectedIndex == 1 && res.ShinyType > 0) || shinyBox.SelectedIndex - 2 == res.ShinyType || shinyBox.SelectedIndex == 0;
        }

        private bool GetIsRowVisible(DataGridViewRow row)
        {
            if (!TryParseCell(row.Cells[1].Value, out int hp) || hp < minHP.Value || hp > maxHP.Value)
                return false;

            if (!TryParseCell(row.Cells[2].Value, out int atk) || atk < minAtk.Value || atk > maxAtk.Value)
                return false;

            if (!TryParseCell(row.Cells[3].Value, out int def) || def < minDef.Value || def > maxDef.Value)
                return false;

            if (!TryParseCell(row.Cells[4].Value, out int spa) || spa < minSpa.Value || spa > maxSpa.Value)
                return false;

            if (!TryParseCell(row.Cells[5].Value, out int spd) || spd < minSpd.Value || spd > maxSpd.Value)
                return false;

            if (!TryParseCell(row.Cells[6].Value, out int spe) || spe < MinSpe.Value || spe > maxSpe.Value)
                return false;

            if (row.Cells[7].Value is not string nature)
                return false;

            if (!natureBox.GetItemChecked(0))
            {
                if (!natureIdx.TryGetValue(nature, out int idx))
                    return false;

                if (!natureBox.GetItemChecked(idx))
                    return false;
            }

            if (row.Cells[8].Value is not string ability ||
                (abilityBox.SelectedIndex != 0 && !abilityBox.Text.StartsWith(ability)))
                return false;

            if (row.Cells[9].Value is not string gender ||
                (genderBox.SelectedIndex != 0 && genderBox.Text != gender))
                return false;

            if (row.Cells[10].Value is not string shiny)
                return false;

            return shinyBox.SelectedIndex switch
            {
                1 => shiny != "No",
                0 => true,
                _ => shinyBox.Text == shiny
            };
        }

        private void SpeciesList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (speciesList.SelectedItem is not ComboboxItem { Value: RaidTemplate pkm }) return;
            var abilities = PersonalTable.SWSH.GetFormEntry(pkm.Species, pkm.AltForm);
            PopulateAbilityList(abilities, pkm.Ability);
            PopulateGenderList(PersonalTable.SWSH[pkm.Species].Gender);

            abilityBox.SelectedIndex = 0;
            genderBox.SelectedIndex = 0;
        }

        private static readonly string[] AbilitySuffix = { " (1)", " (2)", " (H)" };

        private void PopulateAbilityList(IPersonalAbility12H abilities, int a)
        {
            abilityBox.Items.Clear();
            abilityBox.Items.Add("Any");
            var s = GameInfo.Strings;
            for (var i = 0; i < abilities.AbilityCount; i++)
            {
                int ability = abilities.GetAbilityAtIndex(i);
                if (a == 3 && abilityBox.Items.Count == 3)
                    break;

                var name = s.Ability[ability] + AbilitySuffix[i];
                var ab = new ComboboxItem(name, ability);
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

        private async void SearchButton_Click(object sender, EventArgs e)
        {
            if (searchButton.Text == "Stop")
            {
                cts.Cancel();
                searchButton.Text = "Search";
                return;
            }
            var result = WinFormsUtil.Prompt(MessageBoxButtons.YesNo, "This might take a long time. Are you sure you want to start the search?");
            if (result != DialogResult.Yes)
                return;

            ulong start_seed = ulong.Parse(seedBox.Text, System.Globalization.NumberStyles.HexNumber);
            if (!uint.TryParse(startFrame.Text, out uint start_frame))
            {
                start_frame = uint.MaxValue;
            }
            startFrame.Text = start_frame.ToString();
            // uint end_frame = uint.Parse(endFrame.Text);
            raidContent.Rows.Clear();
            searchButton.Text = "Stop";
            cts = new CancellationTokenSource();
            try
            {
                var row = await SearchTask(start_seed, start_frame, cts.Token);
                if (row == null) return;
                //((ISupportInitialize)raidContent).BeginInit();
                raidContent.Rows.Add(row);
                searchButton.Text = "Search";
                //((ISupportInitialize)raidContent).EndInit();
            }
            catch (OperationCanceledException)
            {
                WinFormsUtil.Alert("Stop Search!");
            }
        }

        private async Task<DataGridViewRow?> SearchTask(ulong start_seed, uint start_frame, CancellationToken cancelToken)
        {
            ulong current_seed = Advance(start_seed, start_frame);
            if (speciesList.SelectedItem is not ComboboxItem { Value: RaidTemplate template }) return null;
            var s = GameInfo.Strings;
            return await Task.Run(() =>
            {
                for (uint current_frame = start_frame; ; current_frame++, current_seed += Xoroshiro128Plus.XOROSHIRO_CONST)
                {
                    cancelToken.ThrowIfCancellationRequested();
                    var pkm = template.ConvertToPKM(current_seed, Raids.TID, Raids.SID);
                    if (!IsRowVisible(pkm))
                        continue;
                    return CreateRaidRow(current_frame, pkm, s, current_seed);
                }
            }, cancelToken);
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

        private static bool TryParseCell(object? value, out int result)
        {
            result = 0;
            return value is string s && int.TryParse(s, out result);
        }

        private void RaidContent_SeedCellClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;
            if (e.Button != MouseButtons.Right) return;
            raidContent.CurrentCell = raidContent.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (raidContent.Columns[e.ColumnIndex].Name != "SeedCell") return;
            var cell = raidContent.Rows[e.RowIndex].Cells[e.ColumnIndex];
            if (cell.Value != null && !string.IsNullOrWhiteSpace(cell.Value.ToString()))
            {
                raidContent.CurrentCell = cell;
                seedCellMenu.Show(Cursor.Position);
            }
        }

        private void CopyValueToClipboard_Click(object? sender, EventArgs e)
        {
            if (raidContent.CurrentCell?.Value != null)
            {
                var text = raidContent.CurrentCell.Value.ToString();               
                Clipboard.SetText(text!);
            }
        }

        private void SetSeedValue (object? sender, EventArgs e)
        {
            if (raidContent.CurrentCell != null && raidContent.CurrentCell?.Value != null)
            {
                var text = raidContent.CurrentCell.Value.ToString();
                if (!string.IsNullOrWhiteSpace(text))
                {
                    SelectedSeed = text;
                    DialogResult = DialogResult.OK;
                }
            }
        }
    }
}
