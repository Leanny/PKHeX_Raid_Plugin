using PKHeX.Core;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace PKHeX_Raid_Plugin
{
    public class RaidPlugin : IPlugin
    {
        public string Name => "Swsh Raid Tools";
        public static string Name_Finder => "Raid Seed Finder"; 
        public int Priority => 1;       

        private ToolStripMenuItem? Raid;
        private const string SubMenuParent = "Menu_Tools";
        private const string SubMenuName = "Menu_SwshRaidTools";
        private const string SubMenuText = "Swsh Raid Tools";
        private ISaveFileProvider? _saveFileEditor;

        public ISaveFileProvider SaveFileEditor
        {
            get => _saveFileEditor ?? throw new NullReferenceException(nameof(SaveFileEditor));
            private set => _saveFileEditor = value;
        }

        private bool _isLoaded = false;
        public bool IsLoaded
        {
            get => _isLoaded;
            set
            {
                if (_isLoaded != value)
                {
                    _isLoaded = value;
                    OnPropertyChanged(value);
                }
            }
        }

        protected IPKMView PKMEditor { get; private set; } = new FakePKMEditor(new PK8());

        public void Initialize(params object[] args)
        {
            Debug.WriteLine("[Swsh Raid Tools Plugin] Loading");
            SaveFileEditor = (ISaveFileProvider)(Array.Find(args, z => z is ISaveFileProvider) ?? throw new Exception("Null ISaveFileProvider"));
            PKMEditor = (IPKMView)(Array.Find(args, z => z is IPKMView) ?? throw new Exception("Null IPKMView"));
            var menu = (ToolStrip)(Array.Find(args, z => z is ToolStrip) ?? throw new Exception("Null ToolStrip"));
            LoadMenuStrip(menu);
            
            var sav = SaveFileEditor.SAV;
            if (sav is SAV8SWSH)
               NotifySaveLoaded();
        }

        private void Open()
        {
            var sav = SaveFileEditor.SAV;
            var game = sav.Version;
            if (game != GameVersion.SW && game != GameVersion.SH)
                return;
            var savegame = (SAV8SWSH)sav;

            var form = WinFormsUtil.FirstFormOfType<RaidList>();
            if (form == null)
            {
                form = new RaidList(savegame);
                form.Show();
            }
            else         
                form.Focus();
        }

        private void LoadSeedFinder()
        {
            var sav = SaveFileEditor.SAV;
            var sf = WinFormsUtil.FirstFormOfType<SeedFinder>();
            if (sf == null)
            {
                sf = new SeedFinder((uint)sav.TID16, (uint)sav.SID16);
                var pkm = PKMEditor.PreparePKM();
                if (pkm is PK8 pk8 && pk8.DynamaxLevel != 0)
                    sf.LoadPKM(pk8);
                sf.Show();
            }
            else
                sf.Focus();         
        }

        public void NotifySaveLoaded()
        {
            var sav = SaveFileEditor.SAV;
            IsLoaded = sav is SAV8SWSH; 
        }

        public bool TryLoadFile(string filePath)
        {
            return false;
        }

        private void LoadMenuStrip(ToolStrip menuStrip)
        {
            var items = menuStrip.Items;
            var found = items.Find(SubMenuParent, false);
            if (found.Length == 0 || found[0] is not ToolStripDropDownItem tools)
                return;

            var toolsItems = tools.DropDownItems;
            var searchResults = toolsItems.Find(SubMenuName, false);
            var subMenu = GetSubMenu(tools, searchResults);
            AddSubMenuItems(subMenu);
        }

        private static ToolStripMenuItem GetSubMenu(ToolStripDropDownItem tools, ToolStripItem[] search)
        {
            if (search.Length != 0)
                return (ToolStripMenuItem)search[0];

            var subMenu = CreateBaseGroupItem();
            tools.DropDownItems.Add(subMenu);
            return subMenu;
        }

        private static ToolStripMenuItem CreateBaseGroupItem() => new(SubMenuText) { Image = Properties.Resources.den_ico, Name = SubMenuName };

        private void AddSubMenuItems(ToolStripMenuItem subMenu)
        {
            ToolStripMenuItem raid = new();
            ToolStripMenuItem seedFinder = new();

            ToolStripMenuItem[] subItems =
            [
               Raid = new ("Display Raids") { Name = "Item_Raid", Visible = false, Image = Properties.Resources.display_map},
               seedFinder = new ("Raid Seed Finder") { Name = "Item_SeedFinder", Image = Properties.Resources.seeds }
            ];

            Raid.Click += (s, e) => Open();
            seedFinder.Click += (s, e) => LoadSeedFinder();

            for (int i = 0; i < subItems.Length; i++)
            {              
               subMenu.DropDownItems.Add(subItems[i]);
            }
        }

        private void OnPropertyChanged(Object value)
        {
            if (value is bool isVisible)
            {
               if(Raid != null) { Raid.Visible = isVisible; }
            }
        }
    }
}
