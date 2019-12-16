using PKHeX.Core;
using PKHeX.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PKHeX_Raid_Plugin
{
    public partial class Form1 : Form
    {
        private DenManager dm;

        public Form1(RaidSpawnList8 raids, GameVersion game, int badges, int tid, int sid)
        {
            InitializeComponent();
            dm = new DenManager(raids, game, badges, (uint) tid, (uint) sid);
            denBox.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Den den = dm.GetDen(denBox.SelectedIndex);
            Pkmn pkmn = dm.GetPkmnFromDen(den);
            activeBox.Checked = den.active_den;
            rareBox.Checked = den.rare_den;
            EventBox.Checked = den.event_den;
            denSeed.Text = den.seed.ToString("X");

            // draw stars
            var star = "\u2605";
            var output = star;
            for (int i = 0; i < den.stars; i++) output += star;
            StarLbl.Text = output;
            
            var s = GameInfo.Strings;
            abilityLbl.Text = s.Ability[pkmn.ability];

            natureLbl.Text = s.natures[pkmn.nature];
            TextBox[] ivtextw = { TB_HP_IV1, TB_ATK_IV1, TB_DEF_IV1, TB_SPA_IV1, TB_SPD_IV1, TB_SPE_IV1 };
            for(int i=0; i < 6; i++)
            {
                ivtextw[i].Text = pkmn.ivs[i].ToString();
            }

            Image sprite = PKHeX.Drawing.SpriteUtil.GetSprite(pkmn.species, pkmn.form, pkmn.gender, 0, false, pkmn.shinytype > 0);
            if (pkmn.isGigantamax)
            {
                var gm = Properties.Resources.dyna;
                sprite = ImageUtil.LayerImage(sprite, gm, (sprite.Width - gm.Width) / 2, 0);
            }
            if (!activeBox.Checked)
            {
                sprite = MakeGrayscale((Bitmap) sprite);
            }
            PB_PK1.BackgroundImage = sprite;
            shinyframes.Text = shiny_in(den.seed).ToString();
            locationLabel.Text = den.location;
        }

        private int shiny_in(ulong seed)
        {
            int i = -1;
            ulong new_seed = seed;
            bool shiny = false;
            do
            {
                i++;
                XOROSHIRO rng = new XOROSHIRO(new_seed);
                new_seed = rng.next();
                uint SIDTID = (uint)rng.nextInt(0xFFFFFFFF);
                uint PID = (uint)rng.nextInt(0xFFFFFFFF);
                shiny = (get_SV(SIDTID) ^ get_SV(PID)) == 0x0;
            } while (!shiny);
            return i;
        }

        private uint get_SV(uint num)
        {
            uint high = num >> 16;
            uint low = num & 0xFFFF;
            return (high ^ low) >> 4;
        }

        private static Bitmap MakeGrayscale(Bitmap original)
        {
            // https://web.archive.org/web/20130111215043/http://www.switchonthecode.com/tutorials/csharp-tutorial-convert-a-color-image-to-grayscale
            //make an empty bitmap the same size as original
            Bitmap newBitmap = new Bitmap(original.Width, original.Height);

            for (int i = 0; i < original.Width; i++)
            {
                for (int j = 0; j < original.Height; j++)
                {
                    //get the pixel from the original image
                    Color originalColor = original.GetPixel(i, j);

                    //create the grayscale version of the pixel
                    int grayScale = (int)((originalColor.R * .3) + (originalColor.G * .59)
                        + (originalColor.B * .11));

                    //create the color object
                    Color newColor = Color.FromArgb(originalColor.A, grayScale, grayScale, grayScale);
                    //set the new image's pixel to the grayscale version
                    newBitmap.SetPixel(i, j, newColor);
                }
            }

            return newBitmap;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DenIVs divs = new DenIVs(denBox.SelectedIndex, dm);
            divs.Show();
        }
    }

}
