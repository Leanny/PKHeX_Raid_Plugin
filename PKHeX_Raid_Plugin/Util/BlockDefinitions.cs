using PKHeX.Core;
using System.Collections.Generic;
using System.Reflection;
using System.Linq;

namespace PKHeX_Raid_Plugin;

public struct BlockDefinition
{
    public ulong Offset { get; set; }
    public uint Key { get; set; }
    public int Size { get; set; }
    public string Name { get; set; }
    public string Display { get; set; }
}

public static class BlockDefinitions
{
    public static readonly BlockDefinition MyStatus = new()
    {
        Offset = 0x45068F18,
        Key = 0xF25C070E,
        Size = 0x110,
        Name = "MyStatus",
        Display = "Trainer Data",
    };

    public static readonly BlockDefinition KItems = new()
    {
        Offset = 0x45067A98,
        Key = 0x1177C2C4,
        Size = 0x12F8,
        Name = "KItem",
        Display = "Items",
    };

    public static readonly BlockDefinition Misc = new()
    {
        Offset = 0x45072DF0,
        Key = 0x1B882B09,
        Size = 0x21C,
        Name = "Misc",
        Display = "Miscellaneous",
    };

    public static readonly BlockDefinition TrainerCard = new()
    {
        Offset = 0x45127098,
        Key = 0x874DA6FA,
        Size = 0x1D0,
        Name = "TrainerCard",
        Display = "Trainer Card",
    };

    public static readonly BlockDefinition Fashion = new()
    {
        Offset = 0x450748E8,
        Key = 0xD224F9AC,
        Size = 0xF1C,
        Name = "Fashion",
        Display = "Fashion",
    };

    public static readonly BlockDefinition Raid = new()
    {
        Offset = 0x450C8A70,
        Key = 0x9033eb7b,
        Size = 0xA68,
        Name = "Raid",
        Display = "Raid",
    };

    public static readonly BlockDefinition RaidArmor = new()
    {
        Offset = 0x450C94D8,
        Key = 0x158DA896,
        Size = 0xA68,
        Name = "RaidArmor",
        Display = "RaidArmor",
    };

    public static readonly BlockDefinition RaidCrown = new()
    {
        Offset = 0x450C9F40,
        Key = 0x148DA703,
        Size = 0xA68,
        Name = "RaidCrown",
        Display = "RaidCrown",
    };

    public static readonly BlockDefinition KZukan = new()
    {
        Offset = 0x45069120,
        Key = 0x4716C404,
        Size = 0x4B00,
        Name = "KZukan",
        Display = "Pokedex Base",
    };

    public static readonly BlockDefinition KZukanR1 = new()
    {
        Offset = 0x45069120,
        Key = 0x3F936BA9,
        Size = 0x2790,
        Name = "KZukanR1",
        Display = "Pokedex Armor",
    };

    public static readonly BlockDefinition KZukanR2 = new()
    {
        Offset = 0x45069120,
        Key = 0x3C9366F0,
        Size = 0x2760,
        Name = "KZukanR2",
        Display = "Pokedex Crown",
    };

    public static Dictionary<string, BlockDefinition> GetAllBlocks()
    {
        return typeof(BlockDefinitions)
            .GetFields(BindingFlags.Public | BindingFlags.Static)
            .Where(f => f.FieldType == typeof(BlockDefinition))
            .ToDictionary(f => f.Name, f => (BlockDefinition)f.GetValue(null)!);
    }
}




