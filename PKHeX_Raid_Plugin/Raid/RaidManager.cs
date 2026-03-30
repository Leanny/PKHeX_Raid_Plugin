using System;
using System.Collections.Generic;
using System.Linq;

using PKHeX.Core;

namespace PKHeX_Raid_Plugin
{
    public class RaidManager
    {
        public readonly int BadgeCount;
        public readonly uint TID;
        public readonly uint SID;
        private readonly GameVersion Game;

        private readonly RaidTables _raidTables = new();
       // private readonly RaidParameters[] DenList;
        public IReadOnlyList<RaidParameters> DenList => _denList;
        private readonly RaidParameters[] _denList;


        public RaidManager(SaveBlockAccessor8SWSH blocks, GameVersion game, int badges, uint tid, uint sid)
        {
            EventTableConverter.GetCurrentEventTable(blocks, _raidTables);
            _denList = InitializeDenList(blocks.RaidGalar, blocks.RaidArmor, blocks.RaidCrown);

            Game = game;
            BadgeCount = Util.NumberOfSetBits(badges);
            if (BadgeCount == 0)
                BadgeCount = 9; // enable all dens for basically no SaveFile loaded
            TID = tid;
            SID = sid;
        }

        private static RaidParameters[] InitializeDenList(RaidSpawnList8 raids, RaidSpawnList8 raidsArmor, RaidSpawnList8 raidsCrown)
        {
            // current release has these numbers bugged
            int NormalUsed = raids.CountUsed;
            int ArmorUsed = raidsArmor.CountUsed;
            int CrownUsed = raidsCrown.CountUsed;

            var dl = new RaidParameters[NormalUsed + ArmorUsed + CrownUsed];
            var allRaids = raids.GetAllRaids();           
            for (int i = 0; i < NormalUsed; i++)
            {
                int idx = i;
                var currentRaid = allRaids[i];
                var detail = NestLocations.Nests[i];
                dl[idx] = new RaidParameters(idx, currentRaid, detail.Location, detail.MapX, detail.MapY, RaidRegion.Base);
            }
            
            var allArmorRaids = raidsArmor.GetAllRaids();
            for (int i = 0; i < ArmorUsed; i++)
            {
                int idx = NormalUsed + i;
                var currentRaid = allArmorRaids[i];
                var detail = NestLocations.Nests[idx];
                dl[idx] = new RaidParameters(idx, currentRaid, detail.Location, detail.MapX, detail.MapY, RaidRegion.IsleOfArmor);
            }

            var allCrownRaids = raidsCrown.GetAllRaids();
            for (int i = 0; i < CrownUsed; i++)
            {
                int idx = NormalUsed + ArmorUsed + i;
                var currentRaid = allCrownRaids[i];
                var detail = NestLocations.Nests[idx];
                dl[idx] = new RaidParameters(idx, currentRaid, detail.Location, detail.MapX, detail.MapY, RaidRegion.CrownTundra);
            }

            return dl;
        }

        public RaidParameters this[int index] => DenList[index];

        public RaidPKM GenerateFromIndex(RaidParameters raidParameters)
        {
            if (raidParameters.IsCrystal)
            {
                return _raidTables.CrytalNestsEvent.ConvertToPKM(raidParameters, 0, TID, SID);
            }
            if (raidParameters.IsEvent)
            {
                var denDetails = Game == GameVersion.SW ? _raidTables.SwordNestsEvent : _raidTables.ShieldNestsEvent;
                return denDetails.ConvertToPKM(raidParameters, NestLocations.getEventHash(raidParameters), TID, SID);
            }
            else
            {
                var detail = NestLocations.Nests[raidParameters.Index];
                var hash = raidParameters.IsRare ? detail.RareHash : detail.CommonHash;
                var denDetails = Game == GameVersion.SW ? _raidTables.SwordNests : _raidTables.ShieldNests;
                return denDetails.ConvertToPKM(raidParameters, hash, TID, SID);
            }
        }

        public IEnumerable<RaidTemplate> GetAllTemplatesWithStarCount(RaidParameters raidParameters, int stars)
        {
            if (raidParameters.IsCrystal)
            {
                var tables = _raidTables.CrytalNestsEvent;
                var nest = Array.Find(tables, table => table.TableID == 0)
                     ?? throw new InvalidOperationException("Nest not found.");

                return nest.Entries.AsEnumerable();
            }
            if (raidParameters.IsEvent)
            {
                var tables = Game == GameVersion.SW ? _raidTables.SwordNestsEvent : _raidTables.ShieldNestsEvent;
                var nest = Array.Find(tables, table => table.TableID == NestLocations.EventHash)
                    ?? throw new InvalidOperationException("Event nest not found.");
                return nest.Entries.Where(table => table.CanObtainWith(stars));
            }
            else
            {
                var detail = NestLocations.Nests[raidParameters.Index];
                var tables = Game == GameVersion.SW ? _raidTables.SwordNests : _raidTables.ShieldNests;
                var common = Array.Find(tables, table => table.TableID == detail.CommonHash);
                var rare = Array.Find(tables, table => table.TableID == detail.RareHash);
                var commonEntries = common?.Entries?.Where(table => table.CanObtainWith(stars)) ?? [];
                var rareEntries = rare?.Entries?.Where(table => table.CanObtainWith(stars)) ?? [];

                return commonEntries.Union(rareEntries);
            }
        }
    }
}
