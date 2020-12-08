using System;
using System.Linq;

namespace RollEx.Models
{
    public class PhysicalAttributes
    {
        public double Height { get; set; }
        public double Weight { get; set; }

        public PhysicalAttributes(Race race)
        {
            switch (race)
            {
                case Race.Duck:
                    Height = GetRandomRangeValue(50, 10);
                    Weight = GetRandomRangeValue(3, 4);
                    break;
                case Race.Fox:
                    Height = GetRandomRangeValue(45, 10);
                    Weight = GetRandomRangeValue(4, 4);
                    break;
                case Race.Orc:
                    Height = GetRandomRangeValue(190, 15);
                    Weight = GetRandomRangeValue(110, 20);
                    break;
                case Race.Elf:
                    Height = GetRandomRangeValue(180, 15);
                    Weight = GetRandomRangeValue(75, 25);
                    break;
                case Race.Dwarf:
                    Height = GetRandomRangeValue(120, 5);
                    Weight = GetRandomRangeValue(50, 40);
                    break;
                case Race.Human:
                    Height = GetRandomRangeValue(160, 40);
                    Weight = GetRandomRangeValue(65, 60);
                    break;
                case Race.Pig:
                    Height = GetRandomRangeValue(70, 20);
                    Weight = GetRandomRangeValue(300, 60);
                    break;
                case Race.Zombie:
                    Height = GetRandomRangeValue(160, 40);
                    Weight = GetRandomRangeValue(50, 50);
                    break;
            }
        }

        private double GetRandomRangeValue(int min, int increment)
        {
            var enumer = Enumerable.Range(min, increment);
            var rnd = new Random();

            return rnd.Next(enumer.Min(), enumer.Max());
        }
    }
}
