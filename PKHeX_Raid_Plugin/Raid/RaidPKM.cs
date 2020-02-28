namespace PKHeX_Raid_Plugin
{
    public class RaidPKM
    {
        public readonly int Nature;
        public readonly int Species;
        public readonly int[] IVs;
        public readonly int Gender;
        public readonly uint EC;
        public readonly uint PID;
        public readonly int AltForm;
        public readonly int Ability;
        public readonly uint ShinyType;
        public readonly bool IsGigantamax;
        public readonly sbyte ForcedShinyType;

        public RaidPKM(int species, int altForm, uint ec, uint pid, int[] ivs, int ability, int gender, int nature, uint shinyType, bool isGigantamax, sbyte forcedShinyType = 0)
        {
            Species = species;
            AltForm = altForm;
            EC = ec;
            PID = pid;
            IVs = ivs;
            Ability = ability;
            Gender = gender;
            Nature = nature;
            ShinyType = shinyType;
            IsGigantamax = isGigantamax;
            ForcedShinyType = forcedShinyType;
        }
    }
}