using System;
using System.Collections.Generic;

using Microsoft.Z3;

namespace PKHeX_Raid_Plugin
{
    public static class Z3Search
    {
        public static IEnumerable<ulong> GetSeeds(uint ec, uint pid, int[] ivs)
        {
            foreach (var seed in FindPotentialSeeds(ec, pid, false, ivs))
                yield return seed;
            foreach (var seed in FindPotentialSeeds(ec, pid ^ 0x10000000, false, ivs))
                yield return seed;
            foreach (var seed in FindPotentialSeeds(ec, pid, true, ivs))
                yield return seed;
        }

        public static IEnumerable<ulong> FindPotentialSeeds(uint ec, uint pid, bool shiny, int[] ivs)
        {
            using var ctx = new Context(new Dictionary<string, string> { { "model", "true" } });
            var exp = CreateModel(ctx, ec, pid, shiny, out var s0);

            Model m;
            while ((m = Check(ctx, exp)) != null)
            {
                foreach (var kvp in m.Consts)
                {
                    var tmp = (BitVecNum)kvp.Value;
                    yield return tmp.UInt64; // TODO: Something nicer
                    exp = ctx.MkAnd(exp, ctx.MkNot(ctx.MkEq(s0, m.Evaluate(s0))));
                }
            }
        }

        private static BoolExpr CreateModel(Context ctx, uint ec, uint pid, bool shiny, out BitVecExpr s0)
        {
            s0 = ctx.MkBVConst("s0", 64);
            BitVecExpr s1 = ctx.MkBV(0x82A2B175229D6A5B, 64);
            BitVecExpr and_val = ctx.MkBV(0xFFFFFFFF, 64);
            BitVecExpr and_val16 = ctx.MkBV(0xFFFF, 64);
            BitVecExpr real_ec = ctx.MkBV(ec, 64);
            BitVecExpr real_pid = ctx.MkBV(pid, 64);
            BitVecExpr bit16 = ctx.MkBV(1 << 16, 64);
            BitVecExpr comp_with = ctx.MkBV(0xF, 64);
            var res = AdvanceSymbolic(ctx, s0, s1);
            var ec_check = res.Item1;

            BoolExpr exp = ctx.MkEq(ec_check, real_ec);
            s0 = res.Item2;
            s1 = res.Item3;

            res = AdvanceSymbolic(ctx, s0, s1);
            var tidsid = res.Item1;
            s0 = res.Item2;
            s1 = res.Item3;

            res = AdvanceSymbolic(ctx, s0, s1);
            var pid_check = res.Item1;
            s0 = res.Item2;
            // s1 = res.Item3;

            if (shiny)
            {
                exp = ctx.MkAnd(exp, ctx.MkEq(ctx.MkBVAND(pid_check, and_val16), ctx.MkBVAND(real_pid, and_val16)));
                var st = ctx.MkBVAND(tidsid, and_val);
                var tsv = ctx.MkBVXOR(ctx.MkBVUDiv(st, bit16), ctx.MkBVAND(st, and_val16));
                var psv = ctx.MkBVXOR(ctx.MkBVUDiv(pid_check, bit16), ctx.MkBVAND(pid_check, and_val16));
                return ctx.MkAnd(exp, ctx.MkBVSLE(ctx.MkBVXOR(tsv, psv), comp_with));
            }
            else
            {
                return ctx.MkAnd(exp, ctx.MkEq(pid_check, real_pid));
            }
        }

        private static Tuple<BitVecExpr, BitVecExpr, BitVecExpr> AdvanceSymbolic(Context ctx, BitVecExpr s0, BitVecExpr s1)
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

        private static Model Check(Context ctx, BoolExpr cond)
        {
            Solver solver = ctx.MkSolver();
            solver.Assert(cond);
            Status q = solver.Check();
            if (q != Status.SATISFIABLE)
                throw new Z3Exception("Z3 solver not able to solve");
            return solver.Model;
        }
    }
}