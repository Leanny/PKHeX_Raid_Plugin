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

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Microsoft.Z3;

namespace PKHeX_Raid_Plugin
{
    public partial class SeedFinder : Form
    {
        private readonly uint tid;
        private readonly uint sid;
        public SeedFinder(uint tid, uint sid)
        {
            this.tid = tid;
            this.sid = sid;
            InitializeComponent();
        }

        private void seedBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            char c = e.KeyChar;
            if (!((c >= '0' && c <= '9') || (c >= 'A' && c <= 'F') || (c >= 'a' && c <= 'f') || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void seedSlow_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("This might take several minutes. This method should only be used if the fast one does not yield result. Are you sure you want to use this method?", "Start a search?", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (ECBox.Text.Length == 0) return;
                if (PIDBox.Text.Length == 0) return;
                uint ec = uint.Parse(ECBox.Text, System.Globalization.NumberStyles.HexNumber);
                uint pid = uint.Parse(PIDBox.Text, System.Globalization.NumberStyles.HexNumber);
                int[] ivs = { (int)minHP.Value, (int)minAtk.Value, (int)minDef.Value, (int)minSpa.Value, (int)minSpd.Value, (int)MinSpe.Value, };
                List<UInt64> potential_seeds = find_seeds(ec, pid, tid, sid);
                get_valid_seed(potential_seeds, ivs);
            }

        }

        private static uint get_sv(uint val)
        {
            return (val >> 16) ^ (val & 0xFFFF);
        }

        private void get_valid_seed(List<UInt64> potential_seeds, int[] ivs)
        {
            foreach (UInt64 seed in potential_seeds)
            {
                for(int i=1; i<=5; i++)
                {
                    if (verify_seed(seed, ivs, i))
                    {
                        SeedResult.Text = seed.ToString("X");
                        return;
                    }
                }
            }
            SeedResult.Text = "No seed found";
        }

        private static bool verify_seed(UInt64 seed, int[] ivs, int fixed_ivs)
        {
            XOROSHIRO rng = new XOROSHIRO(seed);
            rng.nextInt(0xFFFFFFFF);
            rng.nextInt(0xFFFFFFFF);
            rng.nextInt(0xFFFFFFFF);
            int[] check_ivs = new int[6] { -1, -1, -1, -1, -1, -1 };
            for(int i=0; i<fixed_ivs; i++)
            {
                uint slot = 0;
                do
                {
                    slot = (uint) rng.nextInt(6);
                } while (check_ivs[slot] != -1);
                if (ivs[slot] != 31) return false;
                check_ivs[slot] = 31;
            }
            for(int i=0; i<6; i++)
            {
                if(check_ivs[i] == -1) { 
                    uint iv = (uint)rng.nextInt(32);
                    if (iv != ivs[i]) return false;
                }
            }
            return true;
        }

        private static int GetShinyType(uint pid, uint tidsid)
        {
            uint a = (pid >> 16) ^ (tidsid >> 16);
            uint b = (pid & 0xFFFF) ^ (tidsid & 0xFFFF);
            if (a == b)
            {
                return 2; // square
            }
            else if ((a ^ b) < 0x10)
            {
                return 1; // star
            }
            return 0;
        }

        private static List<UInt64> find_seeds(uint ec, uint pid, uint tid, uint sid)
        {
            List<UInt64> seeds = new List<ulong>();
            uint tmp = (uint) XOROSHIRO.XOROSHIRO_CONST&0xFFFFFFFF;
            uint fixed_val;
            if (tmp < ec)
            {
                fixed_val = ec - tmp;
            }
            else
            {
                fixed_val = 0xFFFFFFFF - (tmp - ec) + 1;
            }
            uint tsv = (tid ^ sid) >> 4;
            for (ulong i = 0; i <= 0xFFFFFFFF; i++)
            {
                XOROSHIRO rng = new XOROSHIRO(i << 32 | fixed_val);
                rng.nextInt(0xFFFFFFFF);
                uint tidsid = (uint) rng.nextInt(0xFFFFFFFF);
                uint new_pid = (uint)rng.nextInt(0xFFFFFFFF);

                int shinytype = GetShinyType(new_pid, tidsid);
                uint psv = ((new_pid >> 16) ^ (new_pid & 0xFFFF)) >> 4;
                if (shinytype == 0 && psv == tsv) // ensure no shiny
                {
                    new_pid ^= 0x10000000;
                }
                else if (shinytype > 0)
                {
                    if (psv != tsv)
                    {
                        if (shinytype == 1)
                        {
                            new_pid = (new_pid & 0xFFFF) | (tid ^ sid ^ new_pid ^ 1) << 16;
                        }
                        else
                        {
                            new_pid ^= (new_pid & 0xFFFF) | (tid ^ sid ^ new_pid ^ 0) << 16;
                        }
                    }
                }
                if (new_pid == pid)
                {
                    seeds.Add(i << 32 | fixed_val);
                }
            }
            return seeds;
        }

        private Tuple<BitVecExpr, BitVecExpr, BitVecExpr> advance_symbolic(Context ctx, BitVecExpr s0, BitVecExpr s1)
        {
            BitVecExpr and_val = ctx.MkBV(0xFFFFFFFF, 64);
            var res = ctx.MkBVAND(ctx.MkBVAdd(s0, s1), and_val);
            s1 = ctx.MkBVXOR(s0, s1);
            var tmp = ctx.MkBVRotateLeft(24, s0);
            var tmp2 = ctx.MkBV(1 << 16, 64);
            s0 = ctx.MkBVXOR(tmp, ctx.MkBVXOR(s1, ctx.MkBVMul(s1, tmp2)));
            s1 = ctx.MkBVRotateLeft(37, s1);
            return new Tuple<BitVecExpr, BitVecExpr, BitVecExpr>(res, s0, s1);
        }

        private Model check(Context ctx, BoolExpr cond)
        {
            Solver solver = ctx.MkSolver();
            solver.Assert(cond);
            Status q = solver.Check();
            if (q == Status.SATISFIABLE) return solver.Model;
            return null;
        }

        private List<UInt64> find_potential_seeds(uint ec, uint pid, bool shiny)
        {

            int[] ivs = { (int)minHP.Value, (int)minAtk.Value, (int)minDef.Value, (int)minSpa.Value, (int)minSpd.Value, (int)MinSpe.Value, };
            using (Context ctx = new Context(new Dictionary<string, string>() { { "model", "true" } }))
            {
                BitVecExpr s0 = ctx.MkBVConst("s0", 64);
                BitVecExpr s1 = ctx.MkBV(0x82A2B175229D6A5B, 64);
                BitVecExpr and_val = ctx.MkBV(0xFFFFFFFF, 64);
                BitVecExpr and_val16 = ctx.MkBV(0xFFFF, 64);
                BitVecExpr real_ec = ctx.MkBV(ec, 64);
                BitVecExpr real_pid = ctx.MkBV(pid, 64);
                BitVecExpr bit16 = ctx.MkBV(1 << 16, 64);
                BitVecExpr comp_with = ctx.MkBV(0xF, 64);
                var res = advance_symbolic(ctx, s0, s1);
                var ec_check = res.Item1;

                BoolExpr exp = ctx.MkEq(ec_check, real_ec);
                s0 = res.Item2;
                s1 = res.Item3;

                res = advance_symbolic(ctx, s0, s1);
                var tidsid = res.Item1;
                s0 = res.Item2;
                s1 = res.Item3;

                res = advance_symbolic(ctx, s0, s1);
                var pid_check = res.Item1;
                s0 = res.Item2;
                s1 = res.Item3;

                if(shiny)
                {
                    exp = ctx.MkAnd(exp, ctx.MkEq(ctx.MkBVAND(pid_check, and_val16), ctx.MkBVAND(real_pid, and_val16)));
                    var st = ctx.MkBVAND(tidsid, and_val);
                    var tsv = ctx.MkBVXOR(ctx.MkBVUDiv(st, bit16), ctx.MkBVAND(st, and_val16));
                    var psv = ctx.MkBVXOR(ctx.MkBVUDiv(pid_check, bit16), ctx.MkBVAND(pid_check, and_val16));
                    exp = ctx.MkAnd(exp, ctx.MkBVSLE(ctx.MkBVXOR(tsv, psv), comp_with));
                } else
                {
                    exp = ctx.MkAnd(exp, ctx.MkEq(pid_check, real_pid));
                }

                List<UInt64> seeds = new List<UInt64>();
                Model m;
                while ((m = check(ctx, exp)) != null)
                {
                    foreach (var kvp in m.Consts)
                    {
                        var tmp = (BitVecNum)kvp.Value;
                        seeds.Add(tmp.UInt64); // TODO: Something nicer
                        exp = ctx.MkAnd(exp, ctx.MkNot(ctx.MkEq(s0, m.Evaluate(s0))));
                    }
                }
                return seeds;
            }
        }

        private void seedFast_Click(object sender, EventArgs e)
        {
            if (ECBox.Text.Length == 0) return;
            if (PIDBox.Text.Length == 0) return;
            uint ec = uint.Parse(ECBox.Text, System.Globalization.NumberStyles.HexNumber);
            uint pid = uint.Parse(PIDBox.Text, System.Globalization.NumberStyles.HexNumber);
            int[] ivs = { (int)minHP.Value, (int)minAtk.Value, (int)minDef.Value, (int)minSpa.Value, (int)minSpd.Value, (int)MinSpe.Value, };
            List<UInt64> potential_seeds = new List<UInt64>();
            try { 
                foreach(UInt64 seed in find_potential_seeds(ec, pid, false))
                {
                    potential_seeds.Add(seed);
                }
                foreach (UInt64 seed in find_potential_seeds(ec, pid ^ 0x10000000, false))
                {
                    potential_seeds.Add(seed);
                }
                foreach (UInt64 seed in find_potential_seeds(ec, pid, true))
                {
                    potential_seeds.Add(seed);
                }
            } catch(Exception ex)
            {
                MessageBox.Show("This method requires Z3. Please add Z3 to your path.", "Cannot calculate seed");
            }
            get_valid_seed(potential_seeds, ivs);
        }

        private void ECBox_Enter(object sender, EventArgs e)
        {
            TextBox textBox = (TextBox)sender;

            textBox.SelectAll();
        }

        private void minHP_Enter(object sender, EventArgs e)
        {
            NumericUpDown numbox = (NumericUpDown)sender;
            numbox.Select(0, numbox.Text.Length);
        }
    }
}
