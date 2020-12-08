using System;
using System.Collections.Generic;

namespace RollEx.Models
{
    public class CharacterTrait
    {
        public TypeOfTrait TypeOfTrait { get; set; }

        public int Points { get; set; }

        public int GetPoints()
        {
            return Points;
        }

        public void SetPoints(int value)
        {
            Points = value;
        }

        public CharacterTrait(TypeOfTrait typeOfTrait, int points)
        {
            this.TypeOfTrait = typeOfTrait;
            this.SetPoints(points);
        }
    }
}
