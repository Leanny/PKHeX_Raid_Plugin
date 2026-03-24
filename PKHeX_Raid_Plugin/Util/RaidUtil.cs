using System.Drawing;
using PKHeX.Drawing.PokeSprite;
using PKHeX.Drawing;
using PKHeX_Raid_Plugin.Properties;
using PKHeX.Core;
using System.Collections.Generic;

namespace PKHeX_Raid_Plugin
{
    public static class RaidUtil
    {
        private static Shiny[] shinies = { Shiny.Random, Shiny.AlwaysStar, Shiny.AlwaysSquare, Shiny.Never };
        public static string GetStarString(RaidParameters raidParameters)
        {
            const string star = "\u2605";
            var output = star;
            for (int i = 0; i < raidParameters.Stars; i++)
                output += star;
            return output;
        }

        public static Image GetRaidResultSprite(RaidPKM raidPkm, bool active)
        {
            var sprite = SpriteUtil.GetSprite(raidPkm.Species, raidPkm.AltForm, (byte)raidPkm.Gender, 0, 0, false, shinies[raidPkm.ShinyType], EntityContext.Gen8);

            if (raidPkm.IsGigantamax)
            {
                var gm = Resources.dyna;
                sprite = ImageUtil.LayerImage(sprite, gm, (sprite.Width - gm.Width) / 2, 0);
            }

            if (raidPkm.ShinyType == 3)
            {
                // No Shiny
                var icon = Resources.no_shiny;
                sprite = ImageUtil.LayerImage(sprite, icon, 0, 0, 0.7);
            }

            if (!active) { 
                ImageUtil.ToGrayscale(sprite, 1f);
            }

            return sprite;
        }
    }
}