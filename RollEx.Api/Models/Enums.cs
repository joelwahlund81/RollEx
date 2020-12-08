using RollEx.Attributes;

namespace RollEx.Models
{
    public enum TypeOfTrait
    {
        [EnumDescription("Dexterity")]
        Dexterity,
        [EnumDescription("Strength")]
        Strength,
        [EnumDescription("Intelligence")]
        Intelligence,
        [EnumDescription("Charisma")]
        Charisma,
        [EnumDescription("Constitution")]
        Constitution
    }

    public enum Race
    {
        [EnumDescription("Duck")]
        Duck,
        [EnumDescription("Fox")]
        Fox,
        [EnumDescription("Orc")]
        Orc,
        [EnumDescription("Elf")]
        Elf,
        [EnumDescription("Dwarf")]
        Dwarf,
        [EnumDescription("Human")]
        Human,
        [EnumDescription("Pig")]
        Pig,
        [EnumDescription("Zombie")]
        Zombie,

    }

    public enum Gender
    {
        [EnumDescription("Female")]
        Female,
        [EnumDescription("Male")]
        Male,
        [EnumDescription("Unknown")]
        Unknown
    }

    public enum GenerateNamePreference
    {
        Normal,
        Special,
        OneWord
    }
}
