using PKHeX.Core;

namespace PKHeX_Raid_Plugin
{
    public class RaidParameters
    {
        private static readonly string[] LocationNames =
        {
            "Axew's Eye",
            "Bridge Field",
            "Dappled Grove",
            "Dusty Bowl",
            "East Lake Axewell",
            "Giant's Cap",
            "Giant's Mirror",
            "Giant's Seat",
            "Hammerlocke Hills",
            "Lake of Outrage",
            "Motostoke Riverbank",
            "North Lake Miloch",
            "Rolling Fields",
            "South Lake Miloch",
            "Stony Wilderness",
            "Watchtower Ruins",
            "West Lake Axewell"
        };

        public readonly int Flags;
        public readonly int Type;
        public readonly bool IsActive;
        public readonly bool IsEvent;
        public readonly bool IsRare;
        public readonly ulong Seed;
        public readonly int Index;
        public readonly int Stars;
        public readonly int RandRoll;
        public readonly int X;
        public readonly int Y;
        public readonly string Location;

        public RaidParameters(int index, RaidSpawnDetail detail, int location, int x, int y)
            : this(index, detail.Seed, detail.Stars, detail.RandRoll, detail.Flags, detail.DenType, location, x, y) { }

        public RaidParameters(int index, ulong seed, int stars, int randRoll, int flags, int type, int location, int x, int y)
        {
            Seed = seed;
            Flags = flags;
            Type = type;
            IsActive = Type > 0;
            IsRare = Type > 0 && (Type & 1) == 0;
            IsEvent = ((Flags >> 1) & 1) == 1;
            Stars = stars;
            RandRoll = randRoll;
            Index = index;
            Location = LocationNames[location];
            X = x;
            Y = y;
        }
    }
}