using RollEx.Models;

namespace RollEx.Services
{
    public interface IHeroService
    {
        Hero GenerateHero(Race race, Gender gender, GenerateNamePreference generateNamePreference);
        Hero GenerateHero(Gender gender, GenerateNamePreference generateNamePreference);
        Hero GenerateHero(GenerateNamePreference generateNamePreference);
    }
}
