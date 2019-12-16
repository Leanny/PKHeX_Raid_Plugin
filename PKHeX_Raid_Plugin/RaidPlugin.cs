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
