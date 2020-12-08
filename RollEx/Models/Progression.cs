using System.Collections.Generic;
using System.Linq;

namespace RollEx.Models
{
    public class Progression
    {
        private int ExperiencePoints { get; set; }
        private const int Levels = 101;
        private List<ExperiencePointsForGame> ExperiencePointsForGame { get; set; }

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

        public (bool DidLevel, int CurrentLevel) AddExperience(int exp)
        {
            var currentLevel = GetLevelForPoints();

            this.ExperiencePoints += exp;

            var levelWithNewPoints = GetLevelForPoints();

            return (DidLevel: levelWithNewPoints > currentLevel, CurrentLevel: levelWithNewPoints);
        }

        public int RequiredExpToNextLevel()
        {
            var xpToNextLevel = (ExperiencePointsForGame
                .Where(xpt => xpt.ExperiencePoints > this.ExperiencePoints)
                .Select(xpt => xpt.ExperiencePoints)
                .Min()) - this.ExperiencePoints;

            return xpToNextLevel;
        }

        public int GetLevelForPoints()
        {
            var playerlevel = ExperiencePointsForGame
                .Where(xpt => xpt.ExperiencePoints <= this.ExperiencePoints)
                .Select(xpt => xpt.Level)
                .Max();

            return playerlevel;
        }
    }

    public class ExperiencePointsForGame
    {
        public int Level { get; set; }
        public int ExperiencePoints { get; set; }
    }
}
