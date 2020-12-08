using RollEx.Models;
using RollEx.Services;
using Xunit;

namespace RollEx.Tests
{
    public class NameGeneratorTests
    {
        private readonly NameGenerator unitToTest;

        public NameGeneratorTests()
        {
            unitToTest = new NameGenerator();
        }

        [Theory]
        [InlineData(Gender.Male)]
        [InlineData(Gender.Female)]
        [InlineData(Gender.Unknown)]
        public void CheckGender(Gender gender)
        {
            // Act
            var generatedName = unitToTest.GenerateName(gender);
            var hero = new Hero(generatedName);
            
            // Assert
            Assert.True(hero.Gender.Equals(gender));
        }

        [Theory]
        [InlineData(Gender.Male)]
        [InlineData(Gender.Female)]
        [InlineData(Gender.Unknown)]
        public void ShouldContainAnyOfNames(Gender gender)
        {
            // Act
            var generatedName = unitToTest.GenerateName(gender);
            var hero = new Hero(generatedName);

            // Assert
            Assert.False(gender != Gender.Unknown ? hero.OneWordName : !hero.OneWordName);
            if (gender == Gender.Male) Assert.Contains(hero.FirstName, unitToTest.maleFirstNames);
            if (gender == Gender.Female) Assert.Contains(hero.FirstName, unitToTest.femaleFirstNames);
            if (gender == Gender.Unknown) Assert.Contains(hero.FirstName, unitToTest.oneWordNames);
        }

        [Theory]
        [InlineData(Gender.Male, "Homer", "Simpson")]
        [InlineData(Gender.Female, "Marge", "Simpson")]
        public void ShouldGetOrdinarieName(Gender gender, string firstName, string lastName)
        {
            // Arrange
            SetupOrdinarieName(gender, firstName, lastName);
         
            // Act
            var generatedName = unitToTest.GenerateName(gender);
            var hero = new Hero(generatedName);

            // Assert
            Assert.Equal(firstName, hero.FirstName);
            Assert.Equal(lastName, hero.FamilyName);
            Assert.False(hero.OneWordName);
            Assert.True(hero.Gender.Equals(gender));
        }

        [Theory]
        [InlineData(Gender.Unknown, "Homer")]
        [InlineData(Gender.Unknown, "Nisse")]
        [InlineData(Gender.Unknown, "Cooling")]
        public void ShouldReturnOneWordName(Gender gender, string firstName)
        {
            // Arrange
            SetupOneWordName(firstName);

            // Act
            var generatedName = unitToTest.GenerateName(gender);
            var hero = new Hero(generatedName);

            // Assert
            Assert.Equal(firstName, hero.FirstName);
            Assert.True(hero.OneWordName);
            Assert.True(string.IsNullOrEmpty(hero.FamilyName));
            Assert.True(hero.Gender.Equals(gender));
        }

        [Theory]
        [InlineData(Gender.Male, "Homer", "Simpson")]
        public void ShouldGetSpecialName_ForMale(Gender gender, string firstName, string lastName)
        {
            // Arrange
            SetupSpecialName(gender, firstName, lastName);
            
            // Act
            var generatedName = unitToTest.GenerateName(gender, GenerateNamePreference.Special);
            var hero = new Hero(generatedName);

            // Assert
            Assert.Equal(firstName, hero.FirstName);
            Assert.Equal(lastName, hero.FamilyName);
            Assert.False(hero.OneWordName);
            Assert.True(hero.Gender.Equals(gender));
        }

        [Theory]
        [InlineData(Gender.Male, "Homer")]
        [InlineData(Gender.Female, "Marge")]
        public void ShouldGetOneWordName(Gender gender, string firstName)
        {
            // Arrange
            SetupOneWordName(firstName);
            
            // Act
            var generatedName = unitToTest.GenerateName(gender, GenerateNamePreference.OneWord);
            var hero = new Hero(generatedName);

            // Arrange
            Assert.Equal(firstName, hero.FirstName);
            Assert.True(hero.OneWordName);
            Assert.True(string.IsNullOrEmpty(hero.FamilyName));
            Assert.True(hero.Gender.Equals(gender));
        }

        private void SetupOrdinarieName(Gender gender, string firstName, string lastName)
        {
            if (gender.Equals(Gender.Male))
            {
                unitToTest.maleFirstNames = new[] { firstName };
            }
            if (gender.Equals(Gender.Female))
            {
                unitToTest.femaleFirstNames = new[] { firstName };
            }

            unitToTest.lastNames = new[] { lastName };
        }

        private void SetupSpecialName(Gender gender, string firstName, string lastName)
        {
            if (gender.Equals(Gender.Male))
            {
                unitToTest.maleSpecialNames = new[] { $"{firstName} {lastName}" };
            }
            if (gender.Equals(Gender.Female))
            {
                unitToTest.femaleSpecialNames = new[] { $"{firstName} {lastName}" };
            }
        }

        private void SetupOneWordName(string firstName)
        {
            unitToTest.oneWordNames = new[] { firstName };
        }
    }
}
