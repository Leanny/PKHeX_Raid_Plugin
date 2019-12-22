namespace PKHeX_Raid_Plugin
{
    public static class RandUtil
    {
        public static uint GetShinyXor(uint val) => (val >> 16) ^ (val & 0xFFFF);

        public static uint GetShinyValue(uint num) => GetShinyXor(num) >> 4;

        public static uint GetShinyType(uint pid, uint tidsid)
        {
            var p = GetShinyXor(pid);
            var t = GetShinyXor(tidsid);
            if (p == t)
                return 2; // square;
            if ((p ^ t) < 0x10)
                return 1; // star
            return 0;
        }

        public static int GetNextShinyFrame(ulong seed)
        {
            XOROSHIRO rng = new XOROSHIRO(seed);
            for (int i = 0; ; i++)
            {
                rng.Reset(seed);
                seed = rng.Next();
                uint SIDTID = (uint)rng.NextInt(0xFFFFFFFF);
                uint PID = (uint)rng.NextInt(0xFFFFFFFF);
                var type = GetShinyType(PID, SIDTID);
                if (type != 0)
                    return i;
            }
        }
    }
}