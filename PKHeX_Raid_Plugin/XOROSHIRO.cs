using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PKHeX_Raid_Plugin
{
    public class XOROSHIRO
    {

        static ulong[] s = { 0, 0 };

        static ulong rotl(ulong x, int k) {
	        return (x << k) | (x >> (64 - k));
        }

        public XOROSHIRO(ulong seed)
        {
            s[0] = seed;
            s[1] = 0x82A2B175229D6A5B;
        }

        public ulong next()
        {
            ulong s0 = s[0];
            ulong s1 = s[1];
            ulong result = s0 + s1;

            s1 ^= s0;
            s[0] = rotl(s0, 24) ^ s1 ^ (s1 << 16);
            s[1] = rotl(s1, 37);

            return result;
        }

        private ulong nextP2(ulong n)
        {
            n--;
            for(int i=0; i<6; i++)
            {
                n |= n >> (1 << i);
            }
            return n;
        }

        public ulong nextInt(ulong MOD = 0xFFFFFFFF)
        {
            ulong res = 0;
            ulong p2mod = nextP2(MOD);
            do
            {
                res = next() & p2mod;
            } while (res >= MOD);
            return res;
        }
    }
}
