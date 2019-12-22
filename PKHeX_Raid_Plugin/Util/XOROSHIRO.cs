using System.Runtime.CompilerServices;

namespace PKHeX_Raid_Plugin
{
    public class XOROSHIRO
    {
        public const ulong XOROSHIRO_CONST = 0x82A2B175229D6A5B;

        private readonly ulong[] s = { 0, 0 };

        private static ulong RotateLeft(ulong x, int k)
        {
	        return (x << k) | (x >> (64 - k));
        }

        public XOROSHIRO(ulong seed)
        {
            s[0] = seed;
            s[1] = XOROSHIRO_CONST;
        }

        public ulong Next()
        {
            ulong s0 = s[0];
            ulong s1 = s[1];
            ulong result = s0 + s1;

            s1 ^= s0;
            s[0] = RotateLeft(s0, 24) ^ s1 ^ (s1 << 16);
            s[1] = RotateLeft(s1, 37);

            return result;
        }

        public void Reset(ulong seed)
        {
            s[0] = seed;
            s[1] = XOROSHIRO_CONST;
        }

        public ulong NextInt(ulong MOD = 0xFFFFFFFF)
        {
            ulong p2mod = NextP2(MOD) - 1;
            ulong res;
            do
            {
                res = Next() & p2mod;
            } while (res >= MOD);
            return res;
        }

        /// <summary>
        /// Next Power of Two
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static ulong NextP2(ulong x)
        {
            x--; // comment out to always take the next biggest power of two, even if x is already a power of two
            x |= x >> 1;
            x |= x >> 2;
            x |= x >> 4;
            x |= x >> 8;
            x |= x >> 16;
            return x + 1;
        }
    }
}
