using PKHeX.Core;
using System;
using System.Windows.Forms;

namespace PKHeX_Raid_Plugin
{
    public partial class RaidList : Form
    {
        private readonly RaidManager _raids;
        private readonly TextBox[] IVs;

        public RaidList(RaidSpawnList8 raids, GameVersion game, int badges, int tid, int sid)
        {
            InitializeComponent();
            IVs = new[] { TB_HP_IV1, TB_ATK_IV1, TB_DEF_IV1, TB_SPA_IV1, TB_SPD_IV1, TB_SPE_IV1 };
            _raids = new RaidManager(raids, game, badges, (uint)tid, (uint)sid);
            denBox.SelectedIndex = 0;
            CenterToParent();
        }

        private void ChangeDenIndex(object sender, EventArgs e) => LoadDen(_raids[denBox.SelectedIndex]);

        private void ShowDenIVs(object sender, EventArgs e)
        {
            using var divs = new DenIVs(denBox.SelectedIndex, _raids);
            divs.ShowDialog();
        }

        private void LoadDen(RaidParameters raidParameters)
        {
            activeBox.Checked = raidParameters.IsActive;
            rareBox.Checked = raidParameters.IsRare;
            EventBox.Checked = raidParameters.IsEvent;
            denSeed.Text = $"{raidParameters.Seed:X16}";
            StarLbl.Text = RaidUtil.GetStarString(raidParameters);

            var pkm = _raids.GenerateFromIndex(raidParameters);
            var s = GameInfo.Strings;
            abilityLbl.Text = s.Ability[pkm.Ability];
            natureLbl.Text = s.natures[pkm.Nature];

            for (int i = 0; i < 6; i++)
                IVs[i].Text = $"{pkm.IVs[i]:00}";

            PB_PK1.BackgroundImage = RaidUtil.GetRaidResultSprite(pkm, activeBox.Checked);
            shinyframes.Text = RandUtil.GetNextShinyFrame(raidParameters.Seed).ToString();
            locationLabel.Text = raidParameters.Location;

            if (raidParameters.X > 0 && raidParameters.Y > 0)
                DenMap.BackgroundImage = RaidUtil.GetNestMap(raidParameters);
        }
    }
}
