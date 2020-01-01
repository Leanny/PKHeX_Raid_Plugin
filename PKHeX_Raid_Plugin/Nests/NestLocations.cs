namespace PKHeX_Raid_Plugin
{
    public class NestHashDetail
    {
        public readonly ulong CommonHash;
        public readonly ulong RareHash;
        public readonly int Location;
        public readonly int MapX;
        public readonly int MapY;

        public NestHashDetail(ulong common, ulong rare, int location, int mapX, int mapY)
        {
            CommonHash = common;
            RareHash = rare;
            Location = location;
            MapX = mapX;
            MapY = mapY;
        }
    }

    public static class NestLocations
    {
        public const ulong EventHash = 1721953670860364124;

        public static readonly NestHashDetail[] Nests =
        {
            new NestHashDetail(0x173f0456dc5dfc52, 0xba83e1671012ebcd, 12, 185, 977), //16 52
            new NestHashDetail(0x17458556dc634333, 0xba8745671015cb90, 12, 125,1005), //37 64
            new NestHashDetail(0x17458b56dc634d65, 0x450421d99cf882c1, 12, 114, 936), //31 90
            new NestHashDetail(0x17428156dc610690, 0xba805467100fc65f, 12, 311, 998), //03 51
            new NestHashDetail(0x17428856dc611275, 0xba805767100fcb78, 12, 233, 948), //04 46
            new NestHashDetail(0x17458956dc6349ff, 0xba8747671015cef6, 12, 337, 996), //33 62
            new NestHashDetail(0x17459356dc635afd, 0xba8746671015cd43, 12, 209, 976), //39 65
            new NestHashDetail(0x17428356dc6109f6, 0xba805967100fcede, 12, 136, 906), //01 48
            new NestHashDetail(0x17458b56dc634d65, 0x450421d99cf882c1, 12, 252, 905), //31 90
            new NestHashDetail(0x17491656dc666f6d, 0xba83da671012dfe8, 02, 030, 927), //26 59
            new NestHashDetail(0x17490856dc6657a3, 0x17491556dc666dba, 02, 012, 851), //28 79
            new NestHashDetail(0x17491656dc666f6d, 0xba83db671012e19b, 02, 012, 861), //26 58
            new NestHashDetail(0x17428856dc611275, 0x45041fd99cf87f5b, 02, 020, 913), //04 92
            new NestHashDetail(0x17491656dc666f6d, 0xba83da671012dfe8, 02, 040, 878), //26 59
            new NestHashDetail(0x17428256dc610843, 0xba805367100fc4ac, 15, 052, 776), //02 50
            new NestHashDetail(0x17428656dc610f0f, 0xba805867100fcd2b, 15, 068, 652), //06 47
            new NestHashDetail(0x0000000000000000, 0x0000000000000000, 15, 050, 700), //Special
            new NestHashDetail(0x17428556dc610d5c, 0xba805d67100fd5aa, 04, 217, 913), //07 44
            new NestHashDetail(0x17459356dc635afd, 0xba8746671015cd43, 04, 158, 705), //39 65
            new NestHashDetail(0x17458b56dc634d65, 0xba83d8671012dc82, 04, 220, 759), //31 61
            new NestHashDetail(0x17458b56dc634d65, 0xba83d8671012dc82, 04, 248, 852), //31 61
            new NestHashDetail(0x17428b56dc61178e, 0xba8a4e67101810b2, 16, 129, 818), //09 75
            new NestHashDetail(0x17428b56dc61178e, 0xba8a4e67101810b2, 16, 131, 735), //09 75
            new NestHashDetail(0x17501a56dc6c94e7, 0xba805d67100fd5aa, 16, 105, 907), //44 42
            new NestHashDetail(0x17428556dc610d5c, 0xba805d67100fd5aa, 16, 050, 909), //07 44
            new NestHashDetail(0x17428b56dc61178e, 0x450420d99cf8810e, 16, 098, 750), //09 91
            new NestHashDetail(0x17458756dc634699, 0xba8748671015d0a9, 16, 107, 652), //35 63
            new NestHashDetail(0x17459256dc63594a, 0xba8745671015cb90, 00, 186, 816), //38 64
            new NestHashDetail(0x17428c56dc611941, 0x450420d99cf8810e, 13, 310, 824), //08 91
            new NestHashDetail(0x17501b56dc6c969a, 0xba8a496710180833, 13, 359, 980), //41 76
            new NestHashDetail(0x17501b56dc6c969a, 0xba8a496710180833, 13, 393, 962), //41 76
            new NestHashDetail(0x17428756dc6110c2, 0xba805767100fcb78, 13, 328, 761), //05 46
            new NestHashDetail(0x17428356dc6109f6, 0xba805c67100fd3f7, 13, 352, 765), //01 43
            new NestHashDetail(0x173f0356dc5dfa9f, 0xba805467100fc65f, 07, 443, 895), //15 51
            new NestHashDetail(0x173f0056dc5df586, 0xba805e67100fd75d, 07, 388, 817), //12 45
            new NestHashDetail(0x173eff56dc5df3d3, 0xba805a67100fd091, 07, 443, 830), //11 49
            new NestHashDetail(0x173f0356dc5dfa9f, 0x45009ed99cf56e51, 07, 410, 952), //15 83
            new NestHashDetail(0x173eff56dc5df3d3, 0x450097d99cf5626c, 07, 447, 815), //11 84
            new NestHashDetail(0x173efe56dc5df220, 0xba805967100fcede, 11, 393, 781), //10 48
            new NestHashDetail(0x17501b56dc6c969a, 0xba8a496710180833, 11, 314, 755), //41 76
            new NestHashDetail(0x17490756dc6655f0, 0xba83d9671012de35, 11, 440, 658), //29 60
            new NestHashDetail(0x17501b56dc6c969a, 0xba8a496710180833, 11, 281, 717), //41 76
            new NestHashDetail(0x17490756dc6655f0, 0xba83d9671012de35, 11, 440, 703), //29 60
            new NestHashDetail(0x17490756dc6655f0, 0x450425d99cf8898d, 04, 310, 654), //29 86
            new NestHashDetail(0x173efe56dc5df220, 0xba805967100fcede, 11, 443, 792), //10 48
            new NestHashDetail(0x173f0256dc5df8ec, 0xba805367100fc4ac, 10, 412, 533), //14 50
            new NestHashDetail(0x17458a56dc634bb2, 0xba83d9671012de35, 10, 345, 537), //30 60
            new NestHashDetail(0x17491456dc666c07, 0xba83dd671012e501, 10, 365, 559), //24 56
            new NestHashDetail(0x17501c56dc6c984d, 0xba8746671015cd43, 10, 408, 570), //40 65
            new NestHashDetail(0x17458656dc6344e6, 0x45009dd99cf56c9e, 01, 193, 295), //34 82
            new NestHashDetail(0x173f0156dc5df739, 0x450424d99cf887da, 01, 274, 321), //13 87
            new NestHashDetail(0x17428c56dc611941, 0xba805d67100fd5aa, 01, 328, 330), //08 44
            new NestHashDetail(0x173f0456dc5dfc52, 0xba83e1671012ebcd, 01, 370, 452), //16 52
            new NestHashDetail(0x17501c56dc6c984d, 0xba8746671015cd43, 01, 224, 282), //40 65
            new NestHashDetail(0x17428856dc611275, 0x45041fd99cf87f5b, 01, 342, 312), //04 92
            new NestHashDetail(0x17428756dc6110c2, 0xba805767100fcb78, 01, 340, 269), //05 46
            new NestHashDetail(0x17458456dc634180, 0xba8748671015d0a9, 01, 305, 323), //36 63
            new NestHashDetail(0x17491556dc666dba, 0xba83da671012dfe8, 01, 334, 368), //27 59
            new NestHashDetail(0x17501c56dc6c984d, 0xba874b671015d5c2, 14, 343, 222), //40 66
            new NestHashDetail(0x17428356dc6109f6, 0x45009cd99cf56aeb, 14, 348, 195), //01 81
            new NestHashDetail(0x17428156dc610690, 0xba805467100fc65f, 14, 200, 244), //03 51
            new NestHashDetail(0x173f0756dc5e016b, 0x45009bd99cf56938, 14, 305, 183), //19 80
            new NestHashDetail(0x17428656dc610f0f, 0xba805c67100fd3f7, 14, 348, 180), //06 43
            new NestHashDetail(0x17491556dc666dba, 0xba83da671012dfe8, 14, 260, 199), //27 59
            new NestHashDetail(0x17428256dc610843, 0xba805367100fc4ac, 14, 211, 205), //02 50
            new NestHashDetail(0x173f0056dc5df586, 0x450098d99cf5641f, 14, 303, 242), //12 85
            new NestHashDetail(0x17491256dc6668a1, 0xba83de671012e6b4, 14, 324, 209), //22 55
            new NestHashDetail(0x173f0256dc5df8ec, 0xba805367100fc4ac, 14, 326, 219), //14 50
            new NestHashDetail(0x173f0656dc5dffb8, 0xba83df671012e867, 14, 330, 215), //18 54
            new NestHashDetail(0x17458756dc634699, 0xba8748671015d0a9, 14, 282, 195), //35 63
            new NestHashDetail(0x173f0556dc5dfe05, 0x45041ed99cf87da8, 03, 265, 139), //17 93
            new NestHashDetail(0x173f0556dc5dfe05, 0xba83e1671012ebcd, 03, 307, 093), //17 52
            new NestHashDetail(0x173f0356dc5dfa9f, 0x45041ed99cf87da8, 03, 331, 084), //15 93
            new NestHashDetail(0x17428b56dc61178e, 0xba8a4e67101810b2, 03, 219, 099), //09 75
            new NestHashDetail(0x173eff56dc5df3d3, 0xba805a67100fd091, 03, 243, 120), //11 49
            new NestHashDetail(0x173efe56dc5df220, 0xba805967100fcede, 03, 262, 174), //10 48
            new NestHashDetail(0x17490f56dc666388, 0xba83de671012e6b4, 03, 283, 098), //21 55
            new NestHashDetail(0x17491056dc66653b, 0xba83df671012e867, 03, 304, 112), //20 54
            new NestHashDetail(0x17490856dc6657a3, 0xba805c67100fd3f7, 06, 306, 145), //28 43
            new NestHashDetail(0x17458456dc634180, 0x450423d99cf88627, 03, 214, 168), //36 88
            new NestHashDetail(0x17501a56dc6c94e7, 0xba874c671015d775, 06, 334, 145), //42 67
            new NestHashDetail(0x17458456dc634180, 0xba874a671015d40f, 06, 347, 103), //36 69
            new NestHashDetail(0x17491556dc666dba, 0xba874f671015dc8e, 06, 363, 088), //27 70
            new NestHashDetail(0x17491356dc666a54, 0xba8a4d6710180eff, 06, 338, 122), //25 72
            new NestHashDetail(0x173f0056dc5df586, 0xba805e67100fd75d, 08, 339, 035), //12 45
            new NestHashDetail(0x17458856dc63484c, 0xba83d8671012dc82, 08, 310, 065), //32 61
            new NestHashDetail(0x17458a56dc634bb2, 0xba83dc671012e34e, 08, 202, 034), //30 57
            new NestHashDetail(0x173f0756dc5e016b, 0xba83e0671012ea1a, 08, 237, 067), //19 53
            new NestHashDetail(0x17491156dc6666ee, 0xba8a4c6710180d4c, 08, 183, 047), //23 73
            new NestHashDetail(0x17458956dc6349ff, 0xba8747671015cef6, 08, 221, 050), //33 62
            new NestHashDetail(0x173f0256dc5df8ec, 0xba8749671015d25c, 08, 354, 060), //14 68
            new NestHashDetail(0x17458a56dc634bb2, 0xba83d9671012de35, 05, 181, 185), //30 60
            new NestHashDetail(0x17491156dc6666ee, 0xba83de671012e6b4, 05, 199, 145), //23 55
            new NestHashDetail(0x173f0656dc5dffb8, 0xba8750671015de41, 05, 193, 173), //18 71
            new NestHashDetail(0x17458856dc63484c, 0x450422d99cf88474, 05, 202, 095), //32 89
            new NestHashDetail(0x17491456dc666c07, 0x4500a1d99cf5736a, 05, 185, 135), //24 78
            new NestHashDetail(0x17491356dc666a54, 0xba83dd671012e501, 09, 170, 035), //25 56
            new NestHashDetail(0x173f0656dc5dffb8, 0x4500a0d99cf571b7, 09, 128, 058), //18 77
            new NestHashDetail(0x17428c56dc611941, 0xba805d67100fd5aa, 09, 161, 080), //08 44
            new NestHashDetail(0x17458656dc6344e6, 0xba8a4f6710181265, 09, 143, 039), //34 74
        };
    }
}