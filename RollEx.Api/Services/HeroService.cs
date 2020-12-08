using RollEx.Extensions;
using RollEx.Models;

namespace RollEx.Services
{
    public class HeroService : IHeroService
    {
        private readonly INameGenerator nameGenerator;

        public HeroService(INameGenerator nameGenerator)
        {
            this.nameGenerator = nameGenerator;
        }

        public Hero GenerateHero(Race race, Gender gender, GenerateNamePreference generateNamePreference)
        {
            return GenerateHeroS(race, gender, generateNamePreference);
        }

        public Hero GenerateHero(Gender gender, GenerateNamePreference generateNamePreference)
        {
            var race = EnumExtensions.GetRandom<Race>();
       
            return GenerateHeroS(race, gender, generateNamePreference);
        }

        public Hero GenerateHero(GenerateNamePreference generateNamePreference)
        {
            var race = EnumExtensions.GetRandom<Race>();

            var gender = EnumExtensions.GetRandom<Gender>();

            return GenerateHeroS(race, gender, generateNamePreference);
        }

        private Hero GenerateHeroS(Race race, Gender gender, GenerateNamePreference generateNamePreference)
        {
            try
            {
                
                var physicalAttributes = new PhysicalAttributes(race);

                var progression = new Progression();
                var vitals = new Vitals();
                var traits = new Traits();
                var generatedName = nameGenerator.GenerateName(gender, generateNamePreference);

                var hero = new Hero(generatedName, race, physicalAttributes, vitals, progression, traits);

                return hero;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }
    }
}
