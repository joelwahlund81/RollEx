using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RollEx.Models
{
    public class PhysicalAttributes
    {
        public double Height { get; set; }
        public double Weight { get; set; }

        public PhysicalAttributes(Race race)
        {
            var duckHeightRanges = Enumerable.Range(50, 10);
            var duckWeightRanges = Enumerable.Range(3, 4);



            var rnd = new Random();

            switch (race)
            {
                case Race.Duck:
                    Height = rnd.Next(duckHeightRanges.Min(), duckHeightRanges.Max());
                    Weight = rnd.Next(duckWeightRanges.Min(), duckWeightRanges.Max());
                    break;
                case Race.Fox:

                    break;
                case Race.Orc:
                    break;
                case Race.Elf:
                    break;
                case Race.Dwarf:
                    break;
                case Race.Human:
                    break;
            }
        }
        // base on race
    }
}
