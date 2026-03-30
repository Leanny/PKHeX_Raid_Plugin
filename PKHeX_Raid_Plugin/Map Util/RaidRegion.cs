using System;

namespace PKHeX_Raid_Plugin
{
    public enum RaidRegion
    {
        Base,
        IsleOfArmor,
        CrownTundra
    }

    public static class RaidRegions
    {
        public static RaidRegion GetRegion(int index) => index switch
        {
            >= 190 => RaidRegion.CrownTundra,
            >= 100 => RaidRegion.IsleOfArmor,
            _ => RaidRegion.Base
        };
    }
}
