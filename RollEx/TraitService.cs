using RollEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RollEx
{
    public class TraitService
    {
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
        public void AddPoints(int pointsToDistribute, List<CharacterTrait> characterTraits)
        {
            var maxPointToDistribute = 40;
            var rnd = new Random();

            foreach (var trait in characterTraits)
            {
                if (characterTraits.Last() == trait)
                {
                    if (pointsToDistribute > maxPointToDistribute)
                    {
                        AddPoints(40, characterTraits);
                    }
                    
                    trait.Points += pointsToDistribute;
                }
                else
                {
                    var points = GetPoint(rnd, pointsToDistribute, maxPointToDistribute);
                    pointsToDistribute -= points;
                    trait.Points += points;
                }
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
