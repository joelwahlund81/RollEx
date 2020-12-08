using FluentValidation.TestHelper;
using RollEx.Api.Models.Validators;
using Xunit;
using RollEx.Models;

namespace RollEx.Tests.Models.Validators
{
    public class CharacterTraitValidatorTests
    {
        private readonly CharacterTraitValidator unitToTest = new CharacterTraitValidator();

        [Theory]
        [InlineData(TypeOfTrait.Charisma, -1)]
        [InlineData(TypeOfTrait.Constitution, 50)]
        [InlineData(TypeOfTrait.Dexterity, 60)]
        [InlineData(TypeOfTrait.Intelligence, 0)]
        [InlineData(TypeOfTrait.Strength, 100)]
        public void ShouldNotValidateWhenPointsIsNotWithinRange(TypeOfTrait typeOfTrait, int points)
        {
            var trait = new CharacterTrait(typeOfTrait, points);
            
            unitToTest.ShouldHaveValidationErrorFor(x => x.Points, trait);
        }
    }
}
