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

        private readonly RaidTables _raidTables = new RaidTables();
        private readonly RaidParameters[] DenList;

        public RaidManager(SaveBlockAccessor8SWSH blocks, GameVersion game, int badges, uint tid, uint sid)
        {
            EventTableConverter.GetCurrentEventTable(blocks, _raidTables);
            DenList = InitializeDenList(blocks.Raid, blocks.RaidArmor);

            Game = game;
            BadgeCount = Util.NumberOfSetBits(badges);
            if (BadgeCount == 0)
                BadgeCount = 9; // enable all dens for basically no SaveFile loaded
            TID = tid;
            SID = sid;
        }

        private static RaidParameters[] InitializeDenList(RaidSpawnList8 raids, RaidSpawnList8 raidsArmor)
        {
            // current release has these numbers bugged
            const int RaidCountLegal_O0 = 100; // tbd: raids.CountUsed
            const int RaidCountLegal_R1 = 90; // tbd: raidsArmor.CountUsed

            var dl = new RaidParameters[RaidCountLegal_O0 + RaidCountLegal_R1];
            var allRaids = raids.GetAllRaids();
            for (int i = 0; i < RaidCountLegal_O0; i++)
            {
                int idx = i;
                var currentRaid = allRaids[i];
                var detail = NestLocations.Nests[i];
                dl[idx] = new RaidParameters(idx, currentRaid, detail.Location, detail.MapX, detail.MapY);
            }
            
            var allArmorRaids = raidsArmor.GetAllRaids();
            for (int i = 0; i < RaidCountLegal_R1; i++)
            {
                int idx = RaidCountLegal_O0 + i;
                var currentRaid = allArmorRaids[i];
                var detail = NestLocations.Nests[idx];
                dl[idx] = new RaidParameters(idx, currentRaid, detail.Location, detail.MapX, detail.MapY);
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
                var nest = Array.Find(tables, table => table.TableID == 0);
                return nest.Entries.AsEnumerable();
            }
            if (raidParameters.IsEvent)
            {
                var tables = Game == GameVersion.SW ? _raidTables.SwordNestsEvent : _raidTables.ShieldNestsEvent;
                var nest = Array.Find(tables, table => table.TableID == NestLocations.EventHash);
                return nest.Entries.Where(table => table.CanObtainWith(stars));
            }
            else
            {
                var detail = NestLocations.Nests[raidParameters.Index];
                var tables = Game == GameVersion.SW ? _raidTables.SwordNests : _raidTables.ShieldNests;
                var common = Array.Find(tables, table => table.TableID == detail.CommonHash);
                var rare = Array.Find(tables, table => table.TableID == detail.RareHash);
                return common.Entries.Where(table => table.CanObtainWith(stars)).Union(rare.Entries.Where(table => table.CanObtainWith(stars)));
            }
        }
    }
}
