using FluentValidation.TestHelper;
using RollEx.Api.Models.Validators;
using RollEx.Models;
using Xunit;

namespace RollEx.Tests.Models.Validators
{
    public class HeroValidatorTests
    {
        private readonly HeroValidator unitToTest = new HeroValidator();

        [Theory]
        [InlineData(Race.Duck)]
        [InlineData(Race.Dwarf)]
        [InlineData(Race.Elf)]
        [InlineData(Race.Human)]
        [InlineData(Race.Fox)]
        [InlineData(Race.Orc)]
        [InlineData(Race.Pig)]
        [InlineData(Race.Zombie)]
        public void ShouldValidateRace(Race race)
        {
            unitToTest.ShouldNotHaveValidationErrorFor(h => h.Race, race);
        }

        [Theory]
        [InlineData(Race.Duck, 200)]
        [InlineData(Race.Duck, 1)]
        [InlineData(Race.Dwarf, 100)]
        [InlineData(Race.Elf, 300)]
        [InlineData(Race.Human, 24)]
        [InlineData(Race.Fox, 2)]
        [InlineData(Race.Orc, 450)]
        [InlineData(Race.Pig, 42)]
        [InlineData(Race.Zombie, 40)]
        public void ShouldNotValidatePhysicalAttributeWeight(Race race, double weight)
        {
            // Act
            var phWeight = new PhysicalAttributes(race) { Weight = weight };
            var hero = new Hero(null, race, phWeight, null, null, null);

            // Assert
            unitToTest.ShouldHaveValidationErrorFor(h => h.PhysicalAttributes.Weight, hero);
        }

        [Theory]
        [InlineData(Race.Duck, 4)]
        [InlineData(Race.Dwarf, 78)]
        [InlineData(Race.Elf, 75)]
        [InlineData(Race.Human, 125)]
        [InlineData(Race.Fox, 6)]
        [InlineData(Race.Orc, 124)]
        [InlineData(Race.Pig, 230)]
        [InlineData(Race.Zombie, 100)]
        public void ShouldValidatePhysicalAttributeWeight(Race race, double weight)
        {
            // Act
            var phWeight = new PhysicalAttributes(race) { Weight = weight };
            var hero = new Hero(null, race, phWeight, null, null, null);

            // Assert
            unitToTest.ShouldNotHaveValidationErrorFor(h => h.PhysicalAttributes.Weight, hero);
        }

        [Theory]
        [InlineData(Race.Duck, 200)]
        [InlineData(Race.Duck, 1)]
        [InlineData(Race.Dwarf, 100)]
        [InlineData(Race.Elf, 300)]
        [InlineData(Race.Human, 24)]
        [InlineData(Race.Fox, 2)]
        [InlineData(Race.Orc, 450)]
        [InlineData(Race.Pig, 42)]
        [InlineData(Race.Zombie, 40)]
        public void ShouldNotValidatePhysicalAttributeHeight(Race race, double height)
        {
            // Act
            var phWeight = new PhysicalAttributes(race) { Height = height };
            var hero = new Hero(null, race, phWeight, null, null, null);

            // Assert
            unitToTest.ShouldHaveValidationErrorFor(h => h.PhysicalAttributes.Height, hero);
        }

        [Theory]
        [InlineData(Race.Duck, 55)]
        [InlineData(Race.Duck, 50)]
        [InlineData(Race.Duck, 60)]
        [InlineData(Race.Dwarf, 120)]
        [InlineData(Race.Elf, 180)]
        [InlineData(Race.Human, 162)]
        [InlineData(Race.Fox, 45)]
        [InlineData(Race.Orc, 190)]
        [InlineData(Race.Pig, 80)]
        [InlineData(Race.Zombie, 160)]
        public void ShouldValidatePhysicalAttributeHeight(Race race, double height)
        {
            // Act
            var phWeight = new PhysicalAttributes(race) { Height = height };
            var hero = new Hero(null, race, phWeight, null, null, null);

            // Assert
            unitToTest.ShouldNotHaveValidationErrorFor(h => h.PhysicalAttributes.Height, hero);
        }

        //[Theory]
        //[InlineData(" ")]
        //[InlineData("hej")]
        //[InlineData("stick_leave")]
        //public void ShouldNotValidateHeight(string category)
        //{
        //    validator.ShouldHaveValidationErrorFor(x => x.Category, category);
        //}

        // Height is required
        // Weight is required

        //RuleFor(hero => hero.PhysicalAttributes.Height)
        //        .NotNull()
        //        .InclusiveBetween(50, 60)
        //        .WithMessage("Height is required")
        //        .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Duck);
        //RuleFor(hero => hero.PhysicalAttributes.Weight)
        //        .NotNull()
        //        .InclusiveBetween(3, 7)
        //        .WithMessage("Weight is required")
        //        .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Duck);


    }
}
