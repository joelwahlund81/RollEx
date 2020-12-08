using RollEx.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RollEx.Services
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
            "Rotty",
            "Chewchew",
            "Spike",
            "Scott",
            "Petah",
            "Puffy"
        };

        public string[] femaleFirstNames = new[]
        {
            "Rose",
            "Nasrin",
            "Aura",
            "Foxy",
            "Christal",
            "Nazrin",
            "Gathaes",
            "Coraal",
            "Loise",
            "Dora",
            "Yennifeh",
        };

        public string[] lastNames = new[]
        {
            "Gordon",
            "von Hammerschmidt",
            "of Wrath",
            "Sniffer",
            "von Strotterbom",
            "Pewterschmidt",
            "Montana",
            "McGyver",
            "af Klint",
            "of Sawtooth",
            "the Lazy",
            "the Undisputed",
            "Blackwater",
            "the Hateful",
            "Maggot",
            "Stormcrow"
        };

        public string[] maleSpecialNames = new[]
        {
            "Flash Gordon",
            "Com Truise",
            "Blank Puppils",
            "Tore Etsèn",
            "Prad Bitt",
            "Bustin Jieber"
        };

        public string[] femaleSpecialNames = new[]
        {
            "Grrl Powah",
            "Hennifer Jouston",
            "Killer Queen"
        };

        public string[] oneWordNames = new[]
        {
            "Fartface",
            "Deathbreath",
            "Shiny",
            "Death",
            "Squiddles",
            "McLovin",
            "Muffin",
            "Sloth",
            "Wafflemouth",
            "Pants"
        };

        public GeneratedName GenerateName(Gender gender, GenerateNamePreference generateNamePreference = GenerateNamePreference.Normal)
        {
            var rnd = new Random();

            var name = new List<string>(2);

            if (gender == Gender.Unknown)
            {
                name.Add(oneWordNames[rnd.Next(0, oneWordNames.Length - 1)]);
            }
            else
            {
                switch (generateNamePreference)
                {
                    case GenerateNamePreference.Normal:
                        name.Add(gender == Gender.Male ?
                      maleFirstNames[rnd.Next(0, maleFirstNames.Length - 1)] :
                      femaleFirstNames[rnd.Next(0, femaleFirstNames.Length - 1)]);
                        name.Add(lastNames[rnd.Next(0, lastNames.Length - 1)]);
                        break;
                    case GenerateNamePreference.Special:
                        var sName = gender == Gender.Male ?
                       maleSpecialNames[rnd.Next(0, maleSpecialNames.Length - 1)] :
                       femaleSpecialNames[rnd.Next(0, femaleSpecialNames.Length - 1)];
                        name = sName.Split(" ").ToList();
                        break;
                    case GenerateNamePreference.OneWord:
                        name.Add(oneWordNames[rnd.Next(0, oneWordNames.Length - 1)]);
                        break;
                    default:
                        name.Add(gender == Gender.Male ?
                      maleFirstNames[rnd.Next(0, maleFirstNames.Length - 1)] :
                      femaleFirstNames[rnd.Next(0, femaleFirstNames.Length - 1)]);
                        name.Add(lastNames[rnd.Next(0, lastNames.Length - 1)]);
                        break;
                }
            }

            return new GeneratedName(name, gender);
        }
    }

    public class GeneratedName
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool OneWordName { get; set; }
        public Gender Gender { get; set; }

        public GeneratedName(List<string> name, Gender gender)
        {
            Gender = gender;
            SetNames(name);
        }

        public GeneratedName(List<string> name)
        {
            SetNames(name);
        }

        private void SetNames(List<string> name)
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
