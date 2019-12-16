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

namespace PKHeX_Raid_Plugin
{
    public class XOROSHIRO
    {

        public static readonly ulong XOROSHIRO_CONST = 0x82A2B175229D6A5B;

        static ulong[] s = { 0, 0 };

        static ulong rotl(ulong x, int k) {
	        return (x << k) | (x >> (64 - k));
        }

        public XOROSHIRO(ulong seed)
        {
            s[0] = seed;
            s[1] = XOROSHIRO_CONST;
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
