using System;
using System.Windows.Forms;
using System.Diagnostics;

using PKHeX.Core;

namespace PKHeX_Raid_Plugin
{
    public class RaidPlugin : IPlugin
    {
        public string Name => "Display Raids";
        public static string Name_Finder => "Raid Seed Finder";

        public int Priority => 1;

        public ISaveFileProvider SaveFileEditor
        {
            get => _saveFileEditor ?? throw new NullReferenceException(nameof(SaveFileEditor));
            private set => _saveFileEditor = value;
        }

        protected IPKMView PKMEditor { get; private set; } = new FakePKMEditor(new PK8());

        private ToolStripMenuItem? Raid;
        private ToolStripMenuItem? SeedFinder;

        public void Initialize(params object[] args)
        {
            Debug.WriteLine("[Display Raids Plugin] Loading");
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider);
            PKMEditor = (IPKMView)Array.Find(args, z => z is IPKMView);
            var menu = (ToolStrip)Array.Find(args, z => z is ToolStrip);
            var items = menu.Items;
            if (!(items.Find("Menu_Tools", false)[0] is ToolStripDropDownItem tools))
                return;

            Raid = new ToolStripMenuItem(Name) { Visible = false }; // only visible for SW/SH
            Raid.Click += (s, e) => Open();
            tools.DropDownItems.Add(Raid);

            SeedFinder = new ToolStripMenuItem(Name_Finder); // always visible
            SeedFinder.Click += (s, e) => LoadSeedFinder();
            tools.DropDownItems.Add(SeedFinder);

            NotifySaveLoaded();
        }

        private ISaveFileProvider? _saveFileEditor;

        private void Open()
        {
            var sav = SaveFileEditor.SAV;
            var game = (GameVersion)sav.Game;
            if (game != GameVersion.SW && game != GameVersion.SH)
                return;
            var savegame = (SAV8SWSH)sav;
            var f = new RaidList(savegame.Blocks, game, savegame.Badges, savegame.TID16, savegame.SID16);
            f.Show();
        }

        private void LoadSeedFinder()
        {
            var sav = SaveFileEditor.SAV;
            var sf = new SeedFinder((uint)sav.TID16, (uint)sav.SID16);
            var pkm = PKMEditor.PreparePKM();
            if (pkm is PK8 pk8 && pk8.DynamaxLevel != 0)
                sf.LoadPKM(pk8);
            sf.Show();
        }

        public void NotifySaveLoaded()
        {
            if (Raid == null)
                return;
            var sav = SaveFileEditor.SAV;
            Raid.Visible = sav is SAV8SWSH;
        }

        public bool TryLoadFile(string filePath)
        {
            return false;
        }
    }
}
