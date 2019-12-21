using System.Drawing;
using PKHeX.Drawing;
using PKHeX_Raid_Plugin.Properties;

namespace PKHeX_Raid_Plugin
{
    public static class RaidUtil
    {
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
            var sprite = SpriteUtil.GetSprite(raidPkm.Species, raidPkm.AltForm, raidPkm.Gender, 0, false, raidPkm.ShinyType > 0);

            if (raidPkm.IsGigantamax)
            {
                var gm = Resources.dyna;
                sprite = ImageUtil.LayerImage(sprite, gm, (sprite.Width - gm.Width) / 2, 0);
            }

            if (!active)
                sprite = ImageUtil.ToGrayscale(sprite);

            return sprite;
        }

        public static Bitmap GetNestMap(RaidParameters raidParameters)
        {
            Pen redPen = new Pen(Color.Red, 10);
            var map = Resources.map;
            using (var graphics = Graphics.FromImage(map))
                graphics.DrawArc(redPen, raidParameters.X - 5, raidParameters.Y - 5, 15, 15, 0, 360);
            return map;
        }
    }
}