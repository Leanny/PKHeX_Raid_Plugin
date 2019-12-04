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
    public partial class DenIVs : Form
    {
        public DenIVs(ulong seed)
        {
            InitializeComponent();
            for(int i=0; i<150; i++)
            {
                string[] content = {i.ToString(), "", "", "", "", ""};
                for(int k=1; k<6; k++)
                {
                    int[] ivs = getIVs(seed, k);
                    content[k] = string.Format("{0}/{1}/{2}/{3}/{4}/{5}", ivs[0], ivs[1], ivs[2], ivs[3], ivs[4], ivs[5]);
                }
                dataGridView1.Rows.Add(content);
                XOROSHIRO rng = new XOROSHIRO(seed);
                seed = rng.next();
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
            for (int i = 0; i < 6; i++)
            {
                if (ivs[i] == -1) ivs[i] = (int)rng.nextInt(32);
            }
            return ivs;
        }
    }
}
