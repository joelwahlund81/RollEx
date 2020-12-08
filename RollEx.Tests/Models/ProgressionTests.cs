using RollEx.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace RollEx.Tests
{
    public class ProgressionTests
    {
        private Progression unitToTest;

        public ProgressionTests()
        {
            unitToTest = new Progression();
        }

        [Fact]
        public void LevelShouldBeZeroWhenStart()
        {
            var remainingExp = unitToTest.LevelForPoints;

            Assert.Equal(0, remainingExp);
        }

        [Fact]
        public void ExperiencePointsTillNextLevelWhenStart()
        {
            var remainingExp = unitToTest.RequiredExpToNextLevel;

            Assert.Equal(11, remainingExp);
        }

        [Fact]
        public void AddingExperienceShouldLevelUp()
        {
            var (DidLevel, NewLevel) = unitToTest.AddExperience(12);

            Assert.True(DidLevel);
            Assert.Equal(1, NewLevel);
        }

        [Fact]
        public void AddingMuchExperienceShouldReturnCorrectLevel()
        {
            var (DidLevel, NewLevel) = unitToTest.AddExperience(29);

            Assert.True(DidLevel);
            Assert.Equal(2, NewLevel);
        }

        [Fact]
        public void AddingMuchExperienceShouldReturnCorrectExperienceLeft()
        {
            unitToTest.AddExperience(29);
            var experienceLeftToNextLevel = unitToTest.RequiredExpToNextLevel;

            Assert.Equal(10, experienceLeftToNextLevel);
        }

        [Fact]
        public void CheckAvailableLevelsForGameIs100()
        {
            unitToTest.AddExperience(int.MaxValue);
            
            Assert.Equal(100, unitToTest.LevelForPoints);
        }
    }
}
