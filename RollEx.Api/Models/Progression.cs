using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace RollEx.Models
{
    public class Progression
    {
        private const int Levels = 101;

        [JsonPropertyName("xpPoints")]
        public int experiencePoints { get => ExperiencePoints; }

        private int ExperiencePoints { get; set; }

        [JsonPropertyName("xpPointsPerGame")]
        private List<ExperiencePointsForGame> ExperiencePointsForGame { get; set; }

        public int RequiredExpToNextLevel => ExperiencePointsForGame
                    .Where(xpt => xpt.ExperiencePoints > this.ExperiencePoints)
                    .Select(xpt => xpt.ExperiencePoints)
                    .Min() - this.ExperiencePoints;

        public int LevelForPoints => ExperiencePointsForGame
                    .Where(xpt => xpt.ExperiencePoints <= this.ExperiencePoints)
                    .Select(xpt => xpt.Level)
                    .Max();

        public Progression()
        {
            ExperiencePointsForGame = new List<ExperiencePointsForGame>();
            for (int i = 0; i < Levels; i++)
            {
                ExperiencePointsForGame.Add(new ExperiencePointsForGame
                {
                    Level = i,
                    ExperiencePoints = i * (i + 10)
                });
            }
        }

        public (bool, int) AddExperience(int exp)
        {
            var currentLevel = LevelForPoints;

            this.ExperiencePoints += exp;

            var levelWithNewPoints = LevelForPoints;

            return (levelWithNewPoints > currentLevel, levelWithNewPoints);
        }
    }

    public class ExperiencePointsForGame
    {
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
    }
}
