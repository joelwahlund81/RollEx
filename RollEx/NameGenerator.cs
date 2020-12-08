using RollEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RollEx
{
    public class NameGenerator : INameGenerator
    {
        public string[] maleFirstNames = new[]
        {
            "Steve",
            "Muggy",
            "Ismo",
            "Gordy",
            "Boomer",
            "Dinky",
            "Chewchew",
            "Spike"
        };

        public string[] femaleFirstNames = new[]
        {
            "Rose",
            "Nasrin",
            "Aura",
            "Foxy",
            "Coraal",
            "Yennifeh",
        };

        public string[] lastNames = new[]
        {
            "Gordon",
            "von Hammerschmidt",
            "of Wrath",
            "Sniffer",
            "the Undisputed",
            "Blackwater"
        };

        public string[] maleSpecialNames = new[]
        {
            "Flash Gordon",
            "Com Truise",
            "Blank Puppils"
        };

        public string[] femaleSpecialNames = new[]
        {
            "Grrl Powah",
            "Killer Queen"
        };

        public string[] oneWordNames = new[]
        {
            "Fartface",
            "Deathbreath",
            "McLovin",
            "Muffin",
            "Wafflemouth",
            "Shiny",
            "Pants"
        };

        // TODO: Gemerate name based on race
        public GeneratedName GenerateName(Gender gender, bool? specialName = false, bool? oneWordName = false)
        {
            var rnd = new Random();

            var name = new List<string>(2);

            if (gender == Gender.Unknown)
            {
                name.Add(oneWordNames[rnd.Next(0, oneWordNames.Length - 1)]);
            }
            else
            {
                if (!oneWordName.Value && !specialName.Value)
                {
                    name.Add(gender == Gender.Male ?
                        maleFirstNames[rnd.Next(0, maleFirstNames.Length - 1)] :
                        femaleFirstNames[rnd.Next(0, femaleFirstNames.Length - 1)]);

                    name.Add(lastNames[rnd.Next(0, lastNames.Length - 1)]);
                }
                else
                {
                    if (specialName.Value)
                    {
                        var sName = gender == Gender.Male ?
                        maleSpecialNames[rnd.Next(0, maleSpecialNames.Length - 1)] :
                        femaleSpecialNames[rnd.Next(0, femaleSpecialNames.Length - 1)];

                        name = sName.Split(" ").ToList();
                    }
                    if (oneWordName.Value)
                    {
                        name.Add(oneWordNames[rnd.Next(0, oneWordNames.Length - 1)]);
                    }
                }
            }
            return new GeneratedName(name);
        }
    }


    public interface INameGenerator
    {
        GeneratedName GenerateName(Gender gender, bool? specialName, bool? oneWordName);
    }

    public class GeneratedName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool OneWordName { get; set; }

        public GeneratedName(List<string> name)
        {
            FirstName = name[0];

            if (name.Count > 1)
            {
                OneWordName = false;
                LastName = name[1] ?? "";
            }
            else
            {
                OneWordName = true;
            }
        }

    }
}
