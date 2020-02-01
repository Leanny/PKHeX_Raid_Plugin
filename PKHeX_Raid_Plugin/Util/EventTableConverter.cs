using PKHeX.Core;
using PKHeX_Raid_Plugin.Properties;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Linq;

namespace PKHeX_Raid_Plugin
{
    public static class EventTableConverter
    {
        // https://projectpokemon.org/home/forums/topic/56121-swsh-blocks-and-save-research/
        const uint DROP_REWARDS = 0x680EEB85;
        const uint DAI_ENCOUNTER = 0xAD3920F5;
        const uint NORMAL_ENCOUNTER = 0xAD9DFA6A;
        const uint BONUS_REWARDS = 0xEFCAE04E;

        public static void GetCurrentEventTable(SaveBlockAccessor8SWSH blocks, RaidTables rt)
        {
            var archive = blocks.GetBlock(NORMAL_ENCOUNTER).Data;
            if (archive.Length < 0x20 || archive.Length != 4 + BitConverter.ToInt32(archive, 0x10) || BitConverter.ToInt32(archive, 0x8) != 0x20)
                return; // no event loaded
            var encount_data = new byte[archive.Length - 0x24];
            Array.Copy(archive, 0x20, encount_data, 0, encount_data.Length);

            var dist_encounts = DeserializeFrom<NestHoleDistributionEncounter8Archive>(encount_data);
            var sword_table = dist_encounts.Tables.Where(z => z.GameVersion == 1).ToList();
            var shield_table = dist_encounts.Tables.Where(z => z.GameVersion == 2).ToList();
            var swordTable = new RaidTemplateTable(1721953670860364124, 1, new RaidTemplate[sword_table[0].Entries.Length]);
            var shieldTable = new RaidTemplateTable(1721953670860364124, 2, new RaidTemplate[sword_table[0].Entries.Length]);
            for (int i=0; i < sword_table[0].Entries.Length; i++)
            {
                var entry1 = sword_table[0].Entries[i];
                swordTable.Entries[i] = new RaidTemplate(entry1.Species, entry1.Probabilities, entry1.FlawlessIVs, entry1.MinRank, entry1.MaxRank, entry1.AltForm, entry1.Ability, entry1.Gender, entry1.IsGigantamax, entry1.ShinyForced);
                entry1 = shield_table[0].Entries[i];
                shieldTable.Entries[i] = new RaidTemplate(entry1.Species, entry1.Probabilities, entry1.FlawlessIVs, entry1.MinRank, entry1.MaxRank, entry1.AltForm, entry1.Ability, entry1.Gender, entry1.IsGigantamax, entry1.ShinyForced);
            }
            if(sword_table[0].Entries.Length > 0) { 
                rt.SwordNestsEvent[0] = swordTable;
                rt.ShieldNestsEvent[0] = shieldTable;
            }
        }

        public static void LoadFromJson(string filecontent, RaidTables rt)
        {
            var dist_encounts = JsonConvert.DeserializeObject<NestHoleDistributionEncounter8Archive>(filecontent);
            var sword_table = dist_encounts.Tables.Where(z => z.GameVersion == 1).ToList();
            var shield_table = dist_encounts.Tables.Where(z => z.GameVersion == 2).ToList();
            var swordTable = new RaidTemplateTable(1721953670860364124, 1, new RaidTemplate[sword_table[0].Entries.Length]);
            var shieldTable = new RaidTemplateTable(1721953670860364124, 2, new RaidTemplate[sword_table[0].Entries.Length]);
            for (int i = 0; i < sword_table[0].Entries.Length; i++)
            {
                var entry1 = sword_table[0].Entries[i];
                swordTable.Entries[i] = new RaidTemplate(entry1.Species, entry1.Probabilities, entry1.FlawlessIVs, entry1.MinRank, entry1.MaxRank, entry1.AltForm, entry1.Ability, entry1.Gender, entry1.IsGigantamax, entry1.ShinyForced);
                entry1 = shield_table[0].Entries[i];
                shieldTable.Entries[i] = new RaidTemplate(entry1.Species, entry1.Probabilities, entry1.FlawlessIVs, entry1.MinRank, entry1.MaxRank, entry1.AltForm, entry1.Ability, entry1.Gender, entry1.IsGigantamax, entry1.ShinyForced);
            }

            rt.SwordNestsEvent[0] = swordTable;
            rt.ShieldNestsEvent[0] = shieldTable;
        }
        // Copied from pkNX
        private static T DeserializeFrom<T>(byte[] data)
        {
            var path = Path.GetTempFileName();
            File.WriteAllBytes(path, data);
            var ret = DeserializeFrom<T>(path);
            File.Delete(path);
            return ret;
        }

        private static T DeserializeFrom<T>(string file)
        {
            GenerateJsonFromFile<T>(file);
            var text = ReadDeleteJsonFromFolder();
            var obj = JsonConvert.DeserializeObject<T>(text);
            return obj;
        }

        private static string ReadDeleteJsonFromFolder()
        {
            var jsonPath = Directory.GetFiles(FlatPath, "*.json")[0];
            var text = File.ReadAllText(jsonPath);
            File.Delete(jsonPath);
            return text;
        }

        public static readonly string WorkingDirectory = Application.StartupPath;
        public static readonly string FlatPath = Path.Combine(WorkingDirectory, "flatbuffers");

        private static void GenerateJsonFromFile<T>(string file)
        {
            var name = typeof(T).Name;
            var fbsName = name + ".fbs";
            var fbsPath = Path.Combine(FlatPath, fbsName);
            Directory.CreateDirectory(FlatPath);
            if (!File.Exists(fbsPath))
                File.WriteAllBytes(fbsPath, GetSchema(name));

            var fileName = Path.GetFileName(file);
            var filePath = Path.Combine(FlatPath, fileName);
            File.Copy(file, filePath, true);

            var args = GetArgumentsDeserialize(fileName, fbsName);
            RunFlatC(args);
            File.Delete(filePath);
        }

        private static void RunFlatC(string args)
        {
            var fcp = Path.Combine(FlatPath, "flatc.exe");
            if (!File.Exists(fcp))
                File.WriteAllBytes(fcp, Resources.flatc);

            using var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    WorkingDirectory = FlatPath,
                    WindowStyle = ProcessWindowStyle.Hidden,
                    CreateNoWindow = true,
                    FileName = "cmd.exe",
                    Arguments = $"/C flatc {args} & exit",
                }
            };
            process.Start();
            process.WaitForExit();
        }

        private static string GetArgumentsDeserialize(string file, string fbs) => $"-t {fbs} -- {file} --defaults-json --raw-binary";

        public static byte[] GetSchema(string name)
        {
            var obj = Resources.ResourceManager.GetObject(name);
            if (!(obj is byte[] b))
                throw new FileNotFoundException(nameof(name));
            return b;
        }
    }
}
