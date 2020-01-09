using PKHeX.Core;

namespace PKHeX_Raid_Plugin
{
    public class RaidTemplate
    {
        public readonly int Species;
        public readonly int[] Probabilities;
        public readonly int FlawlessIVs;
        public readonly int MinRank;
        public readonly int MaxRank;
        public readonly int AltForm;
        public readonly bool IsGigantamax;
        public readonly int Ability;
        public readonly int Gender;
        public readonly int[] FixedIV;
        public readonly int ShinyType;

        public static readonly int[] ToxtricityAmplifiedNatures = { 0x03, 0x04, 0x02, 0x08, 0x09, 0x13, 0x16, 0x0B, 0x0D, 0x0E, 0x18 };
        public static readonly int[] ToxtricityLowKeyNatures = { 0x01, 0x05, 0x07, 0x0A, 0x0C, 0x0F, 0x10, 0x11, 0x12, 0x14, 0x15, 0x17 };

        public RaidTemplate(int species, int[] probabilities, int flawlessIVs, int minRank, int maxRank, int altForm, int ability, int gender, bool giga, int shinytype = 0)
        {
            Species = species;
            Probabilities = probabilities;
            FlawlessIVs = flawlessIVs;
            MinRank = minRank;
            MaxRank = maxRank;
            AltForm = altForm;
            IsGigantamax = giga;
            Ability = ability;
            Gender = gender;
            ShinyType = shinytype;
            FixedIV = new[] { -1, -1, -1, -1, -1, -1 };
        }

        public RaidTemplate(int species, int[] ivs, int rank, bool giga)
        {
            Species = species;
            MinRank = rank;
            MaxRank = rank;
            FixedIV = ivs;
            IsGigantamax = giga;
            Ability = 3;
            ShinyType = 0;
            FlawlessIVs = -1;
            Probabilities = new[] { 0, 0, 0, 0, 0 };
        }

        public bool CanObtainWith(int stars) => Probabilities[stars] > 0;

        public RaidPKM ConvertToPKM(ulong seed, uint tid, uint sid)
        {
            XOROSHIRO rng = new XOROSHIRO(seed);
            uint EC = (uint)rng.NextInt(0xFFFFFFFF);
            uint SIDTID = (uint)rng.NextInt(0xFFFFFFFF);
            uint PID = (uint)rng.NextInt(0xFFFFFFFF);

            var shinytype = RandUtil.GetShinyType(PID, SIDTID);
            if (ShinyType == 2 && shinytype == 0)
            {
                shinytype = 2;
            }
            uint tsv = RandUtil.GetShinyValue((sid << 16) | tid);
            PID = GetFinalPID(tid, sid, PID, SIDTID, tsv, ShinyType);

            int[] ivs = { -1, -1, -1, -1, -1, -1 };
            for (int i = 0; i < 6; i++)
            {
                 ivs[i] = FixedIV[i];
            }
            for (int i = 0; i < FlawlessIVs; i++)
            {
                int idx;
                do
                {
                    idx = (int)rng.NextInt(6);
                } while (ivs[idx] != -1);
                ivs[idx] = 31;
            }
            for (int i = 0; i < 6; i++)
            {
                if (ivs[i] == -1)
                    ivs[i] = (int)rng.NextInt(32);
            }

            int ability = 0;
            int[] abilities = PersonalTable.SWSH.GetAbilities(Species, AltForm);
            if (Ability < 3)
            {
                ability = abilities[Ability];
            }
            if (Ability == 3)
            {
                ability = abilities[(uint)rng.NextInt(2)];
            }
            else if (Ability == 4)
            {
                ability = abilities[(uint)rng.NextInt(3)];
            }

            // gender 
            int gt = PersonalTable.SWSH[Species].Gender;
            var gender = gt switch
            {
                255 => 2, // Genderless
                254 => 1, // Female-Only
                0 => 0, // Male-Only
                _ => ((int) rng.NextInt(253) + 1 < gt ? 1 : 0)
            };

            int nature;
            if (Species == (int)PKHeX.Core.Species.Toxtricity)
            {
                var table = AltForm == 0 ? ToxtricityAmplifiedNatures : ToxtricityLowKeyNatures;
                nature = table[rng.NextInt((uint)table.Length)];
            }
            else
            {
                nature = (int)rng.NextInt(25);
            }

            return new RaidPKM(Species, AltForm, EC, PID, ivs, ability, gender, nature, shinytype, IsGigantamax);
        }

        public static uint GetFinalPID(uint tid, uint sid, uint new_pid, uint tidsid, uint tsv, int fixedShiny)
        {
            var shinytype = RandUtil.GetShinyType(new_pid, tidsid);
            if (fixedShiny == 2 && shinytype == 0)
            {
                shinytype = 2;
            }
            uint psv = RandUtil.GetShinyValue(new_pid);
            if (shinytype == 0)
            {
                if (psv == tsv)
                    return new_pid ^ 0x10000000; // ensure no shiny
                return new_pid;
            }

            if (psv == tsv)
                return new_pid; // already shiny
            return (new_pid & 0xFFFF) | (tid ^ sid ^ new_pid ^ (2 - shinytype )) << 16;
        }
    }
}