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
        private ulong[][] DenHashes =
        {
            new ulong[]{0x173f0456dc5dfc52, 0xba83e1671012ebcd}, //16 52
            new ulong[]{0x17458556dc634333, 0xba8745671015cb90}, //37 64
            new ulong[]{0x17458b56dc634d65, 0x450421d99cf882c1}, //31 90
            new ulong[]{0x17428156dc610690, 0xba805467100fc65f}, //3 51
            new ulong[]{0x17428856dc611275, 0xba805767100fcb78}, //4 46
            new ulong[]{0x17458956dc6349ff, 0xba8747671015cef6}, //33 62
            new ulong[]{0x17459356dc635afd, 0xba8746671015cd43}, //39 65
            new ulong[]{0x17428356dc6109f6, 0xba805967100fcede}, //1 48
            new ulong[]{0x17458b56dc634d65, 0x450421d99cf882c1}, //31 90
            new ulong[]{0x17491656dc666f6d, 0xba83da671012dfe8}, //26 59
            new ulong[]{0x17491656dc666f6d, 0x17491556dc666dba}, //26 58
            new ulong[]{0x17490856dc6657a3, 0x17491556dc666dba}, //28 79
            new ulong[]{0x17428856dc611275, 0x45041fd99cf87f5b}, //4 92
            new ulong[]{0x17491656dc666f6d, 0xba83da671012dfe8}, //26 59
            new ulong[]{0x17428256dc610843, 0xba805367100fc4ac}, //2 50
            new ulong[]{0x17428656dc610f0f, 0xba805867100fcd2b}, //6 47
            new ulong[]{0x17428556dc610d5c, 0xba805d67100fd5aa}, //7 44
            new ulong[]{0x17459356dc635afd, 0xba8746671015cd43}, //39 65
            new ulong[]{0x17458b56dc634d65, 0xba83d8671012dc82}, //31 61
            new ulong[]{0x17458b56dc634d65, 0xba83d8671012dc82}, //31 61
            new ulong[]{0x17428b56dc61178e, 0x17428556dc610d5c}, //9 75
            new ulong[]{0x17428b56dc61178e, 0x17428556dc610d5c}, //9 75
            new ulong[]{0xba805d67100fd5aa, 0x17501a56dc6c94e7}, //44 42
            new ulong[]{0x17428556dc610d5c, 0xba805d67100fd5aa}, //7 44
            new ulong[]{0x17428b56dc61178e, 0x450420d99cf8810e}, //9 91
            new ulong[]{0x17458756dc634699, 0x17458456dc634180}, //35 63
            new ulong[]{0x17459256dc63594a, 0xba8745671015cb90}, //38 64
            new ulong[]{0x17428c56dc611941, 0x450420d99cf8810e}, //8 91
            new ulong[]{0x17501b56dc6c969a, 0xba8a496710180833}, //41 76
            new ulong[]{0x17501b56dc6c969a, 0xba8a496710180833}, //41 76
            new ulong[]{0x17428756dc6110c2, 0xba805767100fcb78}, //5 46
            new ulong[]{0x17428356dc6109f6, 0xba805c67100fd3f7}, //1 43
            new ulong[]{0x173f0356dc5dfa9f, 0xba805467100fc65f}, //15 51
            new ulong[]{0x173f0056dc5df586, 0xba805e67100fd75d}, //12 45
            new ulong[]{0x173eff56dc5df3d3, 0xba805a67100fd091}, //11 49
            new ulong[]{0x173f0356dc5dfa9f, 0x45009ed99cf56e51}, //15 83
            new ulong[]{0x173eff56dc5df3d3, 0x450097d99cf5626c}, //11 84
            new ulong[]{0x173efe56dc5df220, 0xba805967100fcede}, //10 48
            new ulong[]{0x17501b56dc6c969a, 0xba8a496710180833}, //41 76
            new ulong[]{0x17490756dc6655f0, 0xba83d9671012de35}, //29 60
            new ulong[]{0x17501b56dc6c969a, 0xba8a496710180833}, //41 76
            new ulong[]{0x17490756dc6655f0, 0xba83d9671012de35}, //29 60
            new ulong[]{0x17490756dc6655f0, 0x450425d99cf8898d}, //29 86
            new ulong[]{0x173efe56dc5df220, 0xba805967100fcede}, //10 48
            new ulong[]{0x173f0256dc5df8ec, 0xba805367100fc4ac}, //14 50
            new ulong[]{0x17458a56dc634bb2, 0xba83d9671012de35}, //30 60
            new ulong[]{0x17491456dc666c07, 0x17491356dc666a54}, //24 56
            new ulong[]{0x17501c56dc6c984d, 0xba8746671015cd43}, //40 65
            new ulong[]{0x17458656dc6344e6, 0x45009dd99cf56c9e}, //34 82
            new ulong[]{0x173f0156dc5df739, 0x450424d99cf887da}, //13 87
            new ulong[]{0x17428c56dc611941, 0xba805d67100fd5aa}, //8 44
            new ulong[]{0x173f0456dc5dfc52, 0xba83e1671012ebcd}, //16 52
            new ulong[]{0x17501c56dc6c984d, 0xba8746671015cd43}, //40 65
            new ulong[]{0x17428856dc611275, 0x45041fd99cf87f5b}, //4 92
            new ulong[]{0x17428756dc6110c2, 0xba805767100fcb78}, //5 46
            new ulong[]{0x17458456dc634180, 0x17458456dc634180}, //36 63
            new ulong[]{0x17491556dc666dba, 0xba83da671012dfe8}, //27 59
            new ulong[]{0x17501c56dc6c984d, 0xba874b671015d5c2}, //40 66
            new ulong[]{0x17428356dc6109f6, 0x45009cd99cf56aeb}, //1 81
            new ulong[]{0x17428156dc610690, 0xba805467100fc65f}, //3 51
            new ulong[]{0x173f0756dc5e016b, 0x45009bd99cf56938}, //19 80
            new ulong[]{0x17428656dc610f0f, 0xba805c67100fd3f7}, //6 43
            new ulong[]{0x17491556dc666dba, 0xba83da671012dfe8}, //27 59
            new ulong[]{0x17428256dc610843, 0xba805367100fc4ac}, //2 50
            new ulong[]{0x173f0056dc5df586, 0x450098d99cf5641f}, //12 85
            new ulong[]{0x17491256dc6668a1, 0xba83de671012e6b4}, //22 55
            new ulong[]{0x173f0256dc5df8ec, 0xba805367100fc4ac}, //14 50
            new ulong[]{0x173f0656dc5dffb8, 0x173f0756dc5e016b}, //18 54
            new ulong[]{0x17458756dc634699, 0x17458456dc634180}, //35 63
            new ulong[]{0x173f0556dc5dfe05, 0x45041ed99cf87da8}, //17 93
            new ulong[]{0x173f0556dc5dfe05, 0xba83e1671012ebcd}, //17 52
            new ulong[]{0x173f0356dc5dfa9f, 0x45041ed99cf87da8}, //15 93
            new ulong[]{0x17428b56dc61178e, 0x17428556dc610d5c}, //9 75
            new ulong[]{0x173eff56dc5df3d3, 0xba805a67100fd091}, //11 49
            new ulong[]{0x173efe56dc5df220, 0xba805967100fcede}, //10 48
            new ulong[]{0x17490f56dc666388, 0xba83de671012e6b4}, //21 55
            new ulong[]{0x173f0656dc5dffb8, 0x173f0756dc5e016b}, //20 54
            new ulong[]{0x17490856dc6657a3, 0xba805c67100fd3f7}, //28 43
            new ulong[]{0x17458456dc634180, 0x450423d99cf88627}, //36 88
            new ulong[]{0x17501a56dc6c94e7, 0xba874c671015d775}, //42 67
            new ulong[]{0x17458456dc634180, 0xba874a671015d40f}, //36 69
            new ulong[]{0x17491556dc666dba, 0xba874f671015dc8e}, //27 70
            new ulong[]{0x17491356dc666a54, 0xba8a4d6710180eff}, //25 72
            new ulong[]{0x173f0056dc5df586, 0xba805e67100fd75d}, //12 45
            new ulong[]{0x17458856dc63484c, 0xba83d8671012dc82}, //32 61
            new ulong[]{0x17458a56dc634bb2, 0xba83dc671012e34e}, //30 57
            new ulong[]{0x173f0756dc5e016b, 0xba83e0671012ea1a}, //19 53
            new ulong[]{0x17491156dc6666ee, 0xba8a4c6710180d4c}, //23 73
            new ulong[]{0x17458956dc6349ff, 0xba8747671015cef6}, //33 62
            new ulong[]{0x173f0256dc5df8ec, 0xba8749671015d25c}, //14 68
            new ulong[]{0x17458a56dc634bb2, 0xba83d9671012de35}, //30 60
            new ulong[]{0x17491156dc6666ee, 0xba83de671012e6b4}, //23 55
            new ulong[]{0x173f0656dc5dffb8, 0xba8750671015de41}, //18 71
            new ulong[]{0x17458856dc63484c, 0x450422d99cf88474}, //32 89
            new ulong[]{0x17491456dc666c07, 0x4500a1d99cf5736a}, //24 78
            new ulong[]{0x17491356dc666a54, 0x17491356dc666a54}, //25 56
            new ulong[]{0x173f0656dc5dffb8, 0xba83e0671012ea1a}, //18 77
            new ulong[]{0x17428c56dc611941, 0xba805d67100fd5aa}, //8 44
            new ulong[]{0x17458656dc6344e6, 0xba8a4f6710181265} //34 74
        };

        private const ulong DenEventHash = 1721953670860364124;

        private NestDetails nestDetails = new NestDetails();

        private RaidSpawnList8 raids;
        private ulong seed;
        private GameVersion game;
        public Form1(RaidSpawnList8 raids, GameVersion game)
        {
            InitializeComponent();
            this.raids = raids;
            this.game = game;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // get data 
            int idx = denBox.SelectedIndex;
            if (idx >= 15) idx++; // manual fix due to Den 16 is not included
            var raid = raids.GetAllRaids()[idx];

            // check boxes
            int flags = raid.Flags;
            int type = raid.DenType;
            activeBox.Checked = type > 0;
            rareBox.Checked = type > 0 && (type&1) == 0;
            EventBox.Checked = ((flags>>1)&1) == 1;

            if (activeBox.Checked) {

                // write seed
                denSeed.Text = raid.Seed.ToString("X");
                this.seed = raid.Seed;

                // draw stars
                var star = "\u2605";
                int stars = raid.Stars;
                int roll = raid.RandRoll;
                var output = star;
                for (int i = 0; i < stars; i++) output += star;
                StarLbl.Text = output;

                Nest[] denDetails;
                ulong hash;
                // draw pkmn
                if (EventBox.Checked)
                {
                    hash = DenEventHash;
                    denDetails = this.game == GameVersion.SW?nestDetails.SwordNestsEvent:nestDetails.ShieldNestsEvent;
                } else
                {
                    ulong[] hashes = DenHashes[denBox.SelectedIndex];
                    hash = rareBox.Checked ? hashes[1] : hashes[0];
                    denDetails = this.game == GameVersion.SW ? nestDetails.SwordNests : nestDetails.ShieldNests;

                }
                Nest res = denDetails.Where(nest => nest.TableID == hash).FirstOrDefault();
                Entry pkmn = getPkmn(res.entries, stars, roll);
                Image sprite = PKHeX.Drawing.SpriteUtil.GetSprite(pkmn.Species, pkmn.AltForm, 0, 0, false, false);
                if(pkmn.IsGigantamax)
                {
                    var gm = Properties.Resources.dyna;
                    sprite = ImageUtil.LayerImage(sprite, gm, (sprite.Width - gm.Width) / 2, 0);
                }
                PB_PK1.BackgroundImage = sprite;

                // calculate IVs
                int[] ivs = getIVs(raid.Seed, pkmn.FlawlessIVs);
                TextBox[] ivtextw = { TB_HP_IV1, TB_ATK_IV1, TB_DEF_IV1, TB_SPA_IV1, TB_SPD_IV1, TB_SPE_IV1 };
                for(int i=0; i < 6; i++)
                {
                    ivtextw[i].Text = ivs[i].ToString();
                }
                button1.Enabled = true;
            } else
            {
                denSeed.Text = "";
                StarLbl.Text = "";
                PB_PK1.BackgroundImage = null;
                TextBox[] ivtextw = { TB_HP_IV1, TB_ATK_IV1, TB_DEF_IV1, TB_SPA_IV1, TB_SPD_IV1, TB_SPE_IV1 };
                for (int i = 0; i < 6; i++)
                {
                    ivtextw[i].Text = "";
                }
                button1.Enabled = false;
            }
        }

        private int[] getIVs(ulong seed, int FlawlessIVs)
        {
            XOROSHIRO rng = new XOROSHIRO(seed);
            rng.nextInt();
            rng.nextInt();
            rng.nextInt();
            int[] ivs = { -1, -1, -1, -1, -1, -1 };
            for (int i = 0; i < FlawlessIVs; i++)
            {
                int idx;
                do
                {
                    idx = (int)rng.nextInt(6);
                } while (ivs[idx] != -1);
                ivs[idx] = 31;
            }
            for(int i=0; i<6; i++)
            {
                if (ivs[i] == -1) ivs[i] = (int) rng.nextInt(32);
            }
            return ivs;
        }

        private Entry getPkmn(Entry[] entries, int stars, int roll)
        {
            int i = 0;
            for(int idx = 0; idx < entries.Length; idx++)
            {
                i += entries[idx].Probabilities[stars];
                if (i > roll)
                {
                    return entries[idx];
                }
            }
            return entries[entries.Length - 1];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DenIVs divs = new DenIVs(seed);
            divs.Show();
        }
    }

}
