using PKHeX.Core;
using PKHeX_Raid_Plugin.Properties;
using System;
using Newtonsoft.Json;
using System.Linq;

namespace PKHeX_Raid_Plugin
{
    public static class EventTableConverter
    {
        // https://projectpokemon.org/home/forums/topic/56121-swsh-blocks-and-save-research/
        const uint NORMAL_ENCOUNTER = 0xAD9DFA6A;
        const uint NORMAL_ENCOUNTER_RIGEL1 = 0x0E615A8C;

        public static void GetCurrentEventTable(SaveBlockAccessor8SWSH blocks, RaidTables rt)
        {
            var archive = blocks.GetBlock(NORMAL_ENCOUNTER).Data;
            if (archive.Length < 0x20 || archive.Length != 4 + BitConverter.ToInt32(archive, 0x10) || BitConverter.ToInt32(archive, 0x8) != 0x20)
                return; // no event loaded
            var encount_data = new byte[archive.Length - 0x24];
            Array.Copy(archive, 0x20, encount_data, 0, encount_data.Length);


            var fbb = new FlatBuffers.FlatBufferBuilder(new FlatBuffers.ByteBuffer(encount_data));
            var dist_encounts = PKHeX_Raid_Plugin.NestHoleDistributionEncounter8Archive.GetRootAsNestHoleDistributionEncounter8Archive(fbb.DataBuffer);

            var sword_table = dist_encounts.Tables(0).Value;
            var shield_table = dist_encounts.Tables(1).Value;
            if(sword_table.GameVersion != 1)
            {
                sword_table = dist_encounts.Tables(1).Value;
                shield_table = dist_encounts.Tables(0).Value;
            }

            var swordTable = new RaidTemplateTable(968916678281972007, 1, new RaidTemplate[sword_table.EntriesLength]);
            var shieldTable = new RaidTemplateTable(968916678281972007, 2, new RaidTemplate[sword_table.EntriesLength]);
            for (int i=0; i < sword_table.EntriesLength; i++)
            {
                var entry1 = sword_table.Entries(i).Value;

                swordTable.Entries[i] = new RaidTemplate(entry1.Species, entry1.GetProbabilitiesArray(), entry1.FlawlessIVs, entry1.AltForm, entry1.Ability, entry1.Gender, entry1.Nature, entry1.IsGigantamax, entry1.ShinyForced);
                entry1 = shield_table.Entries(i).Value;
                shieldTable.Entries[i] = new RaidTemplate(entry1.Species, entry1.GetProbabilitiesArray(), entry1.FlawlessIVs, entry1.AltForm, entry1.Ability, entry1.Gender, entry1.Nature, entry1.IsGigantamax, entry1.ShinyForced);
            }
            if (sword_table.EntriesLength > 0) { 
                rt.SwordNestsEvent[0] = swordTable;
                rt.ShieldNestsEvent[0] = shieldTable;
            }

            // Rigel1
            archive = blocks.GetBlock(NORMAL_ENCOUNTER_RIGEL1).Data;
            if (archive.Length < 0x20 || archive.Length != 4 + BitConverter.ToInt32(archive, 0x10) || BitConverter.ToInt32(archive, 0x8) != 0x20)
                return; // no event loaded
            encount_data = new byte[archive.Length - 0x24];
            Array.Copy(archive, 0x20, encount_data, 0, encount_data.Length);


            fbb = new FlatBuffers.FlatBufferBuilder(new FlatBuffers.ByteBuffer(encount_data));
            dist_encounts = PKHeX_Raid_Plugin.NestHoleDistributionEncounter8Archive.GetRootAsNestHoleDistributionEncounter8Archive(fbb.DataBuffer);

            sword_table = dist_encounts.Tables(0).Value;
            shield_table = dist_encounts.Tables(1).Value;
            if (sword_table.GameVersion != 1)
            {
                sword_table = dist_encounts.Tables(1).Value;
                shield_table = dist_encounts.Tables(0).Value;
            }

            var swordTable_rigel1 = new RaidTemplateTable(1721953670860364124, 1, new RaidTemplate[sword_table.EntriesLength]);
            var shieldTable_rigel1 = new RaidTemplateTable(1721953670860364124, 2, new RaidTemplate[sword_table.EntriesLength]);
            for (int i = 0; i < sword_table.EntriesLength; i++)
            {
                var entry1 = sword_table.Entries(i).Value;

                swordTable_rigel1.Entries[i] = new RaidTemplate(entry1.Species, entry1.GetProbabilitiesArray(), entry1.FlawlessIVs, entry1.AltForm, entry1.Ability, entry1.Gender, entry1.Nature, entry1.IsGigantamax, entry1.ShinyForced);
                entry1 = shield_table.Entries(i).Value;
                shieldTable_rigel1.Entries[i] = new RaidTemplate(entry1.Species, entry1.GetProbabilitiesArray(), entry1.FlawlessIVs, entry1.AltForm, entry1.Ability, entry1.Gender, entry1.Nature, entry1.IsGigantamax, entry1.ShinyForced);
            }
            if (sword_table.EntriesLength > 0)
            {
                rt.SwordNestsEvent[1] = swordTable_rigel1;
                rt.ShieldNestsEvent[1] = shieldTable_rigel1;
            }
        }

        public static void LoadFromJson(string filecontent, RaidTables rt)
        {
            var dist_encounts = JsonConvert.DeserializeObject<Old_NestHoleDistributionEncounter8Archive>(filecontent);
            var sword_table = dist_encounts.Tables.Where(z => z.GameVersion == 1).ToList();
            var shield_table = dist_encounts.Tables.Where(z => z.GameVersion == 2).ToList();
            var swordTable = new RaidTemplateTable(1721953670860364124, 1, new RaidTemplate[sword_table[0].Entries.Length]);
            var shieldTable = new RaidTemplateTable(1721953670860364124, 2, new RaidTemplate[sword_table[0].Entries.Length]);
            for (int i = 0; i < sword_table[0].Entries.Length; i++)
            {
                var entry1 = sword_table[0].Entries[i];
                swordTable.Entries[i] = new RaidTemplate(entry1.Species, entry1.Probabilities, entry1.FlawlessIVs, entry1.AltForm, entry1.Ability, entry1.Gender, entry1.Nature, entry1.IsGigantamax, entry1.ShinyForced);
                entry1 = shield_table[0].Entries[i];
                shieldTable.Entries[i] = new RaidTemplate(entry1.Species, entry1.Probabilities, entry1.FlawlessIVs, entry1.AltForm, entry1.Ability, entry1.Gender, entry1.Nature, entry1.IsGigantamax, entry1.ShinyForced);
            }

            rt.SwordNestsEvent[0] = swordTable;
            rt.ShieldNestsEvent[0] = shieldTable;
        }
    }
}
