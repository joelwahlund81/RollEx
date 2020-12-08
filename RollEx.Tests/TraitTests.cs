using System.Collections.Generic;
using Xunit;
using RollEx.Models;
using System.Linq;

namespace RollEx.Tests
{
    public class TraitTests
    {
        private readonly Traits unitToTest;

        public TraitTests()
        {
            unitToTest = new Traits();
        }

        [Fact]
        public void ShouldHavePointsGoingOnce()
        {
            List<CharacterTrait> traits = unitToTest.GetTraitsWithPoints();

            Assert.Equal(100, traits.Sum(t => t.Points));
            traits.ForEach(t => Assert.InRange(t.Points, 0, 40));
        }

        [Fact]
        public void ShouldHavePointsGoingTwice()
        {
            List<CharacterTrait> traits = unitToTest.GetTraitsWithPoints();

            Assert.Equal(100, traits.Sum(t => t.Points));
            traits.ForEach(t => Assert.InRange(t.Points, 0, 40));
        }

        [Fact]
        public void ShouldHavePointsGoingThrice()
        {
            List<CharacterTrait> traits = unitToTest.GetTraitsWithPoints();

            Assert.Equal(100, traits.Sum(t => t.Points));
            traits.ForEach(t => Assert.InRange(t.Points, 0, 40));
        }
    }
}
