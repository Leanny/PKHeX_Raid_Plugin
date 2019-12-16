using PKHeX.Core;
using System;
using System.Windows.Forms;
using System.Diagnostics;

namespace PKHeX_Raid_Plugin
{
    public class RaidPlugin : IPlugin
    {
        public string Name => "Display Raids";

        public int Priority => 1;

        public ISaveFileProvider SaveFileEditor { get; private set; }

        public void Initialize(params object[] args)
        {
            Debug.WriteLine("[Display Raids Plugin] Loading");
            SaveFileEditor = (ISaveFileProvider)Array.Find(args, z => z is ISaveFileProvider);
            var menu = (ToolStrip)Array.Find(args, z => z is ToolStrip);
            var items = menu.Items;
            if (!(items.Find("Menu_Tools", false)[0] is ToolStripDropDownItem tools))
                return;
            var ctrl = new ToolStripMenuItem(Name) { };
            ctrl.Click += (s, e) => Open(SaveFileEditor.SAV);
            tools.DropDownItems.Add(ctrl);
        }
        SAV8SWSH savegame;
        RaidSpawnList8 raids;
        private void Open(SaveFile sav)
        { 
            var game = (GameVersion) sav.Game;
            if (game != GameVersion.SW && game != GameVersion.SH) return;
            savegame = (SAV8SWSH)sav;
            raids = savegame.Blocks.Raid;
            Form1 f = new Form1(raids, game, savegame.Badges, savegame.TID, savegame.SID);
            f.Show();
        }

        public void NotifySaveLoaded()
        {
        }

        public bool TryLoadFile(string filePath)
        {
            return false;
        }
    }
}
