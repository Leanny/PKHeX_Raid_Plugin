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
using System.Collections.Generic;
using System.Linq;

namespace PKHeX_Raid_Plugin
{
    public class DenManager
    {
        private ulong[][] DenHashes =
        {
            new ulong[]{0x173f0456dc5dfc52, 0xba83e1671012ebcd, 12, 185, 977}, //16 52
            new ulong[]{0x17458556dc634333, 0xba8745671015cb90, 12, 125, 1005}, //37 64
            new ulong[]{0x17458b56dc634d65, 0x450421d99cf882c1, 12, 114, 936}, //31 90
            new ulong[]{0x17428156dc610690, 0xba805467100fc65f, 12, 311, 998}, //3 51
            new ulong[]{0x17428856dc611275, 0xba805767100fcb78, 12, 233, 948}, //4 46
            new ulong[]{0x17458956dc6349ff, 0xba8747671015cef6, 12, 337, 996}, //33 62
            new ulong[]{0x17459356dc635afd, 0xba8746671015cd43, 12, 209, 976}, //39 65
            new ulong[]{0x17428356dc6109f6, 0xba805967100fcede, 12, 136, 906}, //1 48
            new ulong[]{0x17458b56dc634d65, 0x450421d99cf882c1, 12, 252, 905}, //31 90
            new ulong[]{0x17491656dc666f6d, 0xba83da671012dfe8, 2, 11, 851}, //26 59
            new ulong[]{0x17491656dc666f6d, 0xba83db671012e19b, 2, 12, 861}, //26 58
            new ulong[]{0x17490856dc6657a3, 0x17491556dc666dba, 2, 12, 851}, //28 79
            new ulong[]{0x17428856dc611275, 0x45041fd99cf87f5b, 2, 20, 913}, //4 92
            new ulong[]{0x17491656dc666f6d, 0xba83da671012dfe8, 2, 40, 878}, //26 59
            new ulong[]{0x17428256dc610843, 0xba805367100fc4ac, 15, 52, 776}, //2 50
            new ulong[]{0x17428656dc610f0f, 0xba805867100fcd2b, 15, 68, 652}, //6 47
            new ulong[]{0x17428556dc610d5c, 0xba805d67100fd5aa, 4, 217, 913}, //7 44
            new ulong[]{0x17459356dc635afd, 0xba8746671015cd43, 4, 158, 705}, //39 65
            new ulong[]{0x17458b56dc634d65, 0xba83d8671012dc82, 4, 220, 759}, //31 61
            new ulong[]{0x17458b56dc634d65, 0xba83d8671012dc82, 4, 248, 852}, //31 61
            new ulong[]{0x17428b56dc61178e, 0xba8a4e67101810b2, 16, 129,818}, //9 75
            new ulong[]{0x17428b56dc61178e, 0xba8a4e67101810b2, 16, 131,735}, //9 75
            new ulong[]{0x17501a56dc6c94e7, 0xba805d67100fd5aa, 16, 105,907}, //44 42
            new ulong[]{0x17428556dc610d5c, 0xba805d67100fd5aa, 16, 50,909}, //7 44
            new ulong[]{0x17428b56dc61178e, 0x450420d99cf8810e, 16, 98, 750}, //9 91
            new ulong[]{0x17458756dc634699, 0x17458456dc634180, 16, 107,652}, //35 63
            new ulong[]{0x17459256dc63594a, 0xba8745671015cb90, 0, 186, 816}, //38 64
            new ulong[]{0x17428c56dc611941, 0x450420d99cf8810e, 13, 310, 824}, //8 91
            new ulong[]{0x17501b56dc6c969a, 0xba8a496710180833, 13, 359,980}, //41 76
            new ulong[]{0x17501b56dc6c969a, 0xba8a496710180833, 13, 393,962}, //41 76
            new ulong[]{0x17428756dc6110c2, 0xba805767100fcb78, 13, 328,761}, //5 46
            new ulong[]{0x17428356dc6109f6, 0xba805c67100fd3f7, 13, 352, 765}, //1 43
            new ulong[]{0x173f0356dc5dfa9f, 0xba805467100fc65f, 7, 443, 895}, //15 51
            new ulong[]{0x173f0056dc5df586, 0xba805e67100fd75d, 7, 388,817}, //12 45
            new ulong[]{0x173eff56dc5df3d3, 0xba805a67100fd091, 7, 443,830}, //11 49
            new ulong[]{0x173f0356dc5dfa9f, 0x45009ed99cf56e51, 7, 410, 952}, //15 83
            new ulong[]{0x173eff56dc5df3d3, 0x450097d99cf5626c, 7, 447, 815}, //11 84
            new ulong[]{0x173efe56dc5df220, 0xba805967100fcede, 11, 393, 781}, //10 48
            new ulong[]{0x17501b56dc6c969a, 0xba8a496710180833, 11, 314,755}, //41 76
            new ulong[]{0x17490756dc6655f0, 0xba83d9671012de35, 11, 440,658}, //29 60
            new ulong[]{0x17501b56dc6c969a, 0xba8a496710180833, 11, 281,717}, //41 76
            new ulong[]{0x17490756dc6655f0, 0xba83d9671012de35, 11, 440,703}, //29 60
            new ulong[]{0x17490756dc6655f0, 0x450425d99cf8898d, 4, 310, 654}, //29 86
            new ulong[]{0x173efe56dc5df220, 0xba805967100fcede, 11, 443,792}, //10 48
            new ulong[]{0x173f0256dc5df8ec, 0xba805367100fc4ac, 10, 412, 533}, //14 50
            new ulong[]{0x17458a56dc634bb2, 0xba83d9671012de35, 10, 345, 537}, //30 60
            new ulong[]{0x17491456dc666c07, 0xba83dd671012e501, 10, 365, 559}, //24 56
            new ulong[]{0x17501c56dc6c984d, 0xba8746671015cd43, 10, 408, 570}, //40 65
            new ulong[]{0x17458656dc6344e6, 0x45009dd99cf56c9e, 1, 193, 295}, //34 82
            new ulong[]{0x173f0156dc5df739, 0x450424d99cf887da, 1, 274, 321}, //13 87
            new ulong[]{0x17428c56dc611941, 0xba805d67100fd5aa, 1, 328, 330}, //8 44
            new ulong[]{0x173f0456dc5dfc52, 0xba83e1671012ebcd, 1, 370, 452}, //16 52
            new ulong[]{0x17501c56dc6c984d, 0xba8746671015cd43, 1, 224, 282}, //40 65
            new ulong[]{0x17428856dc611275, 0x45041fd99cf87f5b, 1, 342, 312}, //4 92
            new ulong[]{0x17428756dc6110c2, 0xba805767100fcb78, 1, 340, 269}, //5 46
            new ulong[]{0x17458456dc634180, 0x17458456dc634180, 1, 305, 323}, //36 63
            new ulong[]{0x17491556dc666dba, 0xba83da671012dfe8, 1, 334, 368}, //27 59
            new ulong[]{0x17501c56dc6c984d, 0xba874b671015d5c2, 14, 343, 222}, //40 66
            new ulong[]{0x17428356dc6109f6, 0x45009cd99cf56aeb, 14, 348, 195}, //1 81
            new ulong[]{0x17428156dc610690, 0xba805467100fc65f, 14, 200, 244}, //3 51
            new ulong[]{0x173f0756dc5e016b, 0x45009bd99cf56938, 14, 305, 183}, //19 80
            new ulong[]{0x17428656dc610f0f, 0xba805c67100fd3f7, 14, 348, 180}, //6 43
            new ulong[]{0x17491556dc666dba, 0xba83da671012dfe8, 14, 260, 199}, //27 59
            new ulong[]{0x17428256dc610843, 0xba805367100fc4ac, 14, 211, 205}, //2 50
            new ulong[]{0x173f0056dc5df586, 0x450098d99cf5641f, 14, 303, 242}, //12 85
            new ulong[]{0x17491256dc6668a1, 0xba83de671012e6b4, 14, 324, 209}, //22 55
            new ulong[]{0x173f0256dc5df8ec, 0xba805367100fc4ac, 14, 326, 219}, //14 50
            new ulong[]{0x173f0656dc5dffb8, 0xba83df671012e867, 14, 330, 215}, //18 54
            new ulong[]{0x17458756dc634699, 0x17458456dc634180, 14, 282, 195}, //35 63
            new ulong[]{0x173f0556dc5dfe05, 0x45041ed99cf87da8, 3, 265, 139}, //17 93
            new ulong[]{0x173f0556dc5dfe05, 0xba83e1671012ebcd, 3, 307, 93}, //17 52
            new ulong[]{0x173f0356dc5dfa9f, 0x45041ed99cf87da8, 3, 331, 84}, //15 93
            new ulong[]{0x17428b56dc61178e, 0xba8a4e67101810b2, 3, 219, 99}, //9 75
            new ulong[]{0x173eff56dc5df3d3, 0xba805a67100fd091, 3, 243, 120}, //11 49
            new ulong[]{0x173efe56dc5df220, 0xba805967100fcede, 3, 262, 174}, //10 48
            new ulong[]{0x17490f56dc666388, 0xba83de671012e6b4, 3, 283, 98}, //21 55
            new ulong[]{0x173f0656dc5dffb8, 0xba83df671012e867, 3, 304, 112}, //20 54
            new ulong[]{0x17490856dc6657a3, 0xba805c67100fd3f7, 6, 306, 145}, //28 43
            new ulong[]{0x17458456dc634180, 0x450423d99cf88627, 3, 214, 168}, //36 88
            new ulong[]{0x17501a56dc6c94e7, 0xba874c671015d775, 6, 334, 145}, //42 67
            new ulong[]{0x17458456dc634180, 0xba874a671015d40f, 6, 347, 103}, //36 69
            new ulong[]{0x17491556dc666dba, 0xba874f671015dc8e, 6, 363, 88}, //27 70
            new ulong[]{0x17491356dc666a54, 0xba8a4d6710180eff, 6, 338, 122}, //25 72
            new ulong[]{0x173f0056dc5df586, 0xba805e67100fd75d, 8, 339, 35}, //12 45
            new ulong[]{0x17458856dc63484c, 0xba83d8671012dc82, 8, 310, 65}, //32 61
            new ulong[]{0x17458a56dc634bb2, 0xba83dc671012e34e, 8, 202, 34}, //30 57
            new ulong[]{0x173f0756dc5e016b, 0xba83e0671012ea1a, 8, 237, 67}, //19 53
            new ulong[]{0x17491156dc6666ee, 0xba8a4c6710180d4c, 8, 183, 47}, //23 73
            new ulong[]{0x17458956dc6349ff, 0xba8747671015cef6, 8, 221, 50}, //33 62
            new ulong[]{0x173f0256dc5df8ec, 0xba8749671015d25c, 8, 354, 60}, //14 68
            new ulong[]{0x17458a56dc634bb2, 0xba83d9671012de35, 5, 181, 185}, //30 60
            new ulong[]{0x17491156dc6666ee, 0xba83de671012e6b4, 5, 199, 145}, //23 55
            new ulong[]{0x173f0656dc5dffb8, 0xba8750671015de41, 5, 193, 173}, //18 71
            new ulong[]{0x17458856dc63484c, 0x450422d99cf88474, 5, 202, 95}, //32 89
            new ulong[]{0x17491456dc666c07, 0x4500a1d99cf5736a, 5, 185, 135}, //24 78
            new ulong[]{0x17491356dc666a54, 0xba83dd671012e501, 9, 170, 35}, //25 56
            new ulong[]{0x173f0656dc5dffb8, 0x4500a0d99cf571b7, 9, 128, 58}, //18 77
            new ulong[]{0x17428c56dc611941, 0xba805d67100fd5aa, 9, 161, 80}, //8 44
            new ulong[]{0x17458656dc6344e6, 0xba8a4f6710181265, 9, 143, 39}, //34 74


        };

        private const ulong DenEventHash = 1721953670860364124;

        private readonly int[] ToxtricityAmplifiedNatures = { 0x03, 0x04, 0x02, 0x08, 0x09, 0x13, 0x16, 0x0B, 0x0D, 0x0E, 0x18 };
        private readonly int[] ToxtricityLowKeyNatures    = { 0x01, 0x05, 0x07, 0x0A, 0x0C, 0x0F, 0x10, 0x11, 0x12, 0x14, 0x15, 0x17 };

        private NestDetails nestDetails = new NestDetails();

        private RaidSpawnList8 raids;
        private GameVersion game;
        public readonly int badges;
        private readonly uint tid;
        private readonly uint sid;
        private Den[] denList;

        private static int NumberOfSetBits(int i)
        {
            i = i - ((i >> 1) & 0x55555555);
            i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
            return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
        }

        public DenManager(RaidSpawnList8 raids, GameVersion game, int badges, uint tid, uint sid)
        {
            this.raids = raids;
            this.game = game;
            this.badges = NumberOfSetBits(badges);
            if (this.badges == 0)
            {
                this.badges = 9; // enable all dens for basically no savegame loaded
            }
            this.tid = tid;
            this.sid = sid;

            this.denList = new Den[99];
            var allRaids = raids.GetAllRaids();
            for (int i=0; i<99; i++)
            {
                int idx = i;
                if (idx >= 15) idx++;
                var currentRaid = allRaids[idx];
                Den den = new Den(i, currentRaid.Seed, currentRaid.Stars, currentRaid.RandRoll, currentRaid.Flags, currentRaid.DenType, (int) DenHashes[i][2], (int)DenHashes[i][3], (int)DenHashes[i][4]);
                this.denList[i] = den;
            }
        }

        public Den GetDen(int idx)
        {
            return this.denList[idx];
        }

        public Pkmn GetPkmnFromDen(Den den)
        {
            Nest[] denDetails;
            ulong hash;
            if (den.event_den)
            {
                hash = DenEventHash;
                denDetails = this.game == GameVersion.SW ? nestDetails.SwordNestsEvent : nestDetails.ShieldNestsEvent;
            }
            else
            {
                ulong[] hashes = DenHashes[den.idx];
                hash = den.rare_den ? hashes[1] : hashes[0];
                denDetails = this.game == GameVersion.SW ? nestDetails.SwordNests : nestDetails.ShieldNests;
            }
            Nest res = denDetails.Where(nest => nest.TableID == hash).FirstOrDefault();
            Entry pkmn = getPkmn(res.entries, den.stars, den.roll);
            return GetPkmnFromDetails(den.seed, pkmn);
        }

        public IEnumerable<Entry> GetAllEntriesWithStarcount(Den den, int stars)
        {
            if (den.event_den)
            {
                Nest[] denDetails = this.game == GameVersion.SW ? nestDetails.SwordNestsEvent : nestDetails.ShieldNestsEvent;
                Nest res = denDetails.Where(nest => nest.TableID == DenEventHash).FirstOrDefault();
                return res.entries.Where(nest => nest.Probabilities[stars] > 0);
            }
            else
            {
                ulong[] hashes = DenHashes[den.idx];
                Nest[] denDetails = this.game == GameVersion.SW ? nestDetails.SwordNests : nestDetails.ShieldNests;
                Nest res = denDetails.Where(nest => nest.TableID == hashes[0]).FirstOrDefault();
                Nest res2 = denDetails.Where(nest => nest.TableID == hashes[1]).FirstOrDefault();
                return res.entries.Where(nest => nest.Probabilities[stars] > 0).Union(res2.entries.Where(nest => nest.Probabilities[stars] > 0));
            }
        }

        public Pkmn GetPkmnFromDetails(ulong seed, Entry pkmn) 
        { 
            XOROSHIRO rng = new XOROSHIRO(seed);
            uint EC = (uint) rng.nextInt(0xFFFFFFFF);
            uint SIDTID = (uint)rng.nextInt(0xFFFFFFFF);
            uint PID = (uint)rng.nextInt(0xFFFFFFFF);
            int shinytype = GetShinyType(PID, SIDTID);
            uint tsv = get_SV((this.sid << 16) | this.tid);
            uint psv = get_SV(PID);
            if (shinytype == 0 && psv == tsv) // ensure no shiny
            {
                PID ^= 0x10000000;
            } else if(shinytype > 0) {
                if (psv != tsv) { 
                    if (shinytype == 1) { 
                        PID = (PID&0xFFFF ) | (this.tid ^ this.sid ^ PID ^ 1) << 16;
                    } else
                    {
                        PID ^= (PID & 0xFFFF) | (this.tid ^ this.sid ^ PID ^ 0) << 16;
                    }
                }
            }
            int[] ivs = { -1, -1, -1, -1, -1, -1 };
            for (int i = 0; i < pkmn.FlawlessIVs; i++)
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
            int ability = 0;
            int[] abilities = PersonalTable.SWSH.GetAbilities(pkmn.Species, pkmn.AltForm);
            if (pkmn.Ability == 3)
            {
                ability = abilities[(uint)rng.nextInt(2)];
            }
            else if (pkmn.Ability == 4)
            {
                ability = abilities[(uint)rng.nextInt(3)];
            }

            // gender 
            int gender = 0; // 0 = male, 1 = female, 2 = genderless
            int gt = PersonalTable.SWSH[pkmn.Species].Gender;
            switch (gt)
            {
                case 255:
                    gender = 2; // Genderless
                    break;
                case 254:
                    gender = 1; // Female-Only
                    break;
                case 0:
                    gender = 0; // Male-Only
                    break;
                default:
                    gender = (int)rng.nextInt(253) + 1 < gt ? 1 : 0;
                    break;
            }
            int nature;
            if(pkmn.Species == (int) Species.Toxtricity)
            {
                if(pkmn.AltForm == 0)
                {
                    nature = ToxtricityAmplifiedNatures[(uint)rng.nextInt((uint)ToxtricityAmplifiedNatures.Length)];
                } else
                {
                    nature = ToxtricityAmplifiedNatures[(uint)rng.nextInt((uint)ToxtricityLowKeyNatures.Length)];
                }
            } else
            {
                nature = (int)rng.nextInt(25);
            }

            return new Pkmn(pkmn.Species, pkmn.AltForm, EC, PID, ivs, ability, gender,nature, shinytype, pkmn.IsGigantamax);
        }

        private uint get_SV(uint num)
        {
            uint high = num >> 16;
            uint low = num & 0xFFFF;
            return (high ^ low) >> 4;
        }

        private int GetShinyType(uint pid, uint tidsid)
        {
            uint a = (pid >> 16) ^ (tidsid >> 16);
            uint b = (pid & 0xFFFF) ^ (tidsid & 0xFFFF);
            if (a == b)
            {
                return 2; // square
            } else if((a^b) < 0x10)
            {
                return 1; // star
            }
            return 0;
        }

        private Entry getPkmn(Entry[] entries, int stars, int roll)
        {
            int i = 0;
            for (int idx = 0; idx < entries.Length; idx++)
            {
                i += entries[idx].Probabilities[stars];
                if (i > roll)
                {
                    return entries[idx];
                }
            }
            return entries[entries.Length - 1];
        }

    }

    public class Den
    {
        private static readonly string[] LocationNames =
        {
            "Axew's Eye", "Bridge Field", "Dappled Grove", "Dusty Bowl", "East Lake Axewell", "Giant's Cap", "Giant's Mirror",
            "Giant's Seat", "Hammerlocke Hills", "Lake of Outrage", "Motostoke Riverbank", "North Lake Miloch", "Rolling Fields",
            "South Lake Miloch", "Stony Wilderness", "Watchtower Ruins", "West Lake Axewell"
        };

        public readonly int flags;
        public readonly int type;
        public readonly bool active_den;
        public readonly bool event_den;
        public readonly bool rare_den;
        public readonly ulong seed;
        public readonly int idx;
        public readonly int stars;
        public readonly int roll;
        public readonly int x;
        public readonly int y;
        public readonly string location;

        public Den(int idx, ulong seed, int stars, int roll, int flags, int type, int location, int x, int y)
        {
            this.seed = seed;
            this.flags = flags;
            this.type = type;
            this.active_den = this.type > 0;
            this.rare_den = this.type > 0 && (this.type & 1) == 0;
            this.event_den = ((this.flags >> 1) & 1) == 1;
            this.stars = stars;
            this.roll = roll;
            this.idx = idx;
            this.location = LocationNames[location];
            this.x = x;
            this.y = y;
        }


    }

    public class Pkmn
    {
        public readonly int nature;
        public readonly int species;
        public readonly int[] ivs;
        public readonly int gender;
        public readonly uint EC;
        public readonly uint PID;
        public readonly int form;
        public readonly int ability;
        public readonly int shinytype;
        public readonly bool isGigantamax;

        public Pkmn(int species, int form, uint EC, uint PID, int[] ivs, int ability, int gender, int nature, int shinytype, bool isGigantamax)
        {
            this.species = species;
            this.form = form;
            this.EC = EC;
            this.PID = PID;
            this.ivs = ivs;
            this.ability = ability;
            this.gender = gender;
            this.nature = nature;
            this.shinytype = shinytype;
            this.isGigantamax = isGigantamax;
        }
    }
}
