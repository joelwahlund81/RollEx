using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace RollEx.Models
{
    public class Traits
    {
        [JsonPropertyName("traits_list")]
        public List<CharacterTrait> GetAllTraits => CharacterTraits;

        private List<CharacterTrait> CharacterTraits { get; set; }

        public Traits()
        {
            CharacterTraits = GetTraitsWithPoints();
        }

        public List<CharacterTrait> GetTraitsWithPoints()
        {
            var traitEnums = Enum.GetValues(typeof(TypeOfTrait)).Cast<TypeOfTrait>().ToList();
            var traits = new List<CharacterTrait>();

            var pointsToDistribute = 100;
            var maxPointToDistribute = 40;
            var rnd = new Random();

            foreach (var item in traitEnums)
            {
                if (traitEnums.Last() == item)
                {
                    if (pointsToDistribute > maxPointToDistribute)
                    {
                        return GetTraitsWithPoints();
                    }
                    traits.Add(new CharacterTrait(item, pointsToDistribute));
                }
                else
                {
                    var points = GetPoint(rnd, pointsToDistribute, maxPointToDistribute);
                    pointsToDistribute -= points;

                    traits.Add(new CharacterTrait(item, points));
                }
            }

            return traits;
        }

        // Göra rekursivt, kanske använda Action som en parameter så man kan oavsett ..
        // ..varifrån man anropar alltid kan anropa sig själv
        public void AddPoints(int pointsToDistribute)
        {
            var maxPointToDistribute = 40;
            var rnd = new Random();

            foreach (var trait in this.CharacterTraits)
            {
                if (this.CharacterTraits.Last() == trait)
                {
                    if (pointsToDistribute > maxPointToDistribute)
                    {
                        AddPoints(maxPointToDistribute);
                    }
                }
                else
                {
                    var points = GetPoint(rnd, pointsToDistribute, maxPointToDistribute);
                    pointsToDistribute -= points;
                }

                trait.SetPoints(trait.Points + pointsToDistribute);
            }
        }

        private int GetPoint(Random rnd, int pointsLeft, int maxPoints)
        {
            var p = rnd.Next(0, pointsLeft);

            if (p > maxPoints)
            {
                return GetPoint(rnd, pointsLeft, maxPoints);
            }

            return p;
        }
    }
}
