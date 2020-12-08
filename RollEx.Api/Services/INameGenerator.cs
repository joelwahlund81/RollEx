using RollEx.Models;

namespace RollEx.Services
{
    public interface INameGenerator
    {
        GeneratedName GenerateName(Gender gender, GenerateNamePreference generateNamePreference = GenerateNamePreference.Normal);
    }
}
