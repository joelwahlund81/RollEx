using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using RollEx.Api.Controllers;
using RollEx.Models;
using RollEx.Services;
using Xunit;

namespace RollEx.Tests
{
    public class HeroControllerTests
    {
        private readonly INameGenerator nameGenerator;

        private readonly Mock<IHeroService> heroServiceMock;
        
        private readonly HeroController unitToTest;

        public HeroControllerTests()
        {
            nameGenerator = new NameGenerator();

            heroServiceMock = new Mock<IHeroService>();

            unitToTest = new HeroController(heroServiceMock.Object);
        }

        [Theory]
        [InlineData(Gender.Female, GenerateNamePreference.Normal)]
        [InlineData(Gender.Male, GenerateNamePreference.Special)]
        [InlineData(Gender.Unknown, GenerateNamePreference.OneWord)]
        public void ShouldReturnOkWhenUsingGet(Gender gender, GenerateNamePreference generateNamePreference)
        {
            // Arrange
            // heroServiceMock.Setup(h => h.GenerateHero(generateNamePreference)).Returns(new Hero(nameGenerator.GenerateName(gender)));
            //var s = new IHeroService();
            var unitToTest = new HeroController(new HeroService(nameGenerator));


            // Act
            var result = unitToTest.Get(generateNamePreference);

            // Asserts
            Assert.IsAssignableFrom<OkObjectResult>((OkObjectResult)result);
            var okObjectResult = result as OkObjectResult;
            Assert.IsAssignableFrom<Hero>(okObjectResult.Value);
            Assert.NotNull(okObjectResult.Value);
            Assert.Equal(StatusCodes.Status200OK, okObjectResult.StatusCode);
        }

        [Fact]
        public void ShouldReturnServerErrorWhenGettingActivityLogsGoesWrong()
        {
            //// Act
            //heroServiceMock.Setup(h => h.GenerateHero(false, false)).Returns(() => null);

            //// Act
            //var result = unitToTest.Get();

            //// Assert
            //Assert.IsType<ObjectResult>((ObjectResult)result);
            //var serverError = result as ObjectResult;
            //Assert.IsAssignableFrom<Exception>(serverError.Value);
            //Assert.Equal(StatusCodes.Status500InternalServerError, serverError.StatusCode);
        }
    }
}
