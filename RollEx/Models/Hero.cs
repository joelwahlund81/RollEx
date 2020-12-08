using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Text;

namespace RollEx.Models
{
    public class Hero
    {
        public string FirstName { get; set; }
        public string FamilyName { get; set; }
        public bool OneWordName { get; set; }

        public Gender Gender { get; set; }
        public Race Race { get; set; }

        private Vitals Vitals { get; set; }
        private Progression Progression { get; set; }
        private PhysicalAttributes PhysicalAttributes { get; set; }

        private const int TraitPointsToUseWhenLevel = 10;
        private const int HealthMultiplierWhenLevel = 100;

        // TODO: Lägg i en egen klass, och inte en service som måste initieras vid varje användning
        private List<CharacterTrait> Traits { get; set; }
        // ta fram bestämda värden för olika egenskaper baserat på värden från traits
        // exempel inom vilket omfång kan karaktären slå i styrka
        // beräkna om när man levlar och ökar på varje trait

        // kanske ska lägga egenskaperna för att generera saker via hjälten
        // exempelvis ha en metod på Hero som beräknar chansen att undvika slag
        // då hämtar den Trait för Dexterity och dess värde


        public Hero(Gender gender, GeneratedName generatedName)
        {
            Gender = gender;
            Race = race;
            FirstName = generatedName.FirstName;
            FamilyName = generatedName.LastName;
            OneWordName = generatedName.OneWordName;

            PhysicalAttributes = new PhysicalAttributes(race);

            Progression = new Progression();
            Vitals = new Vitals();

            var service = new TraitService();
            Traits = service.GetTraitsWithPoints();
        }

        public void AddExperiencePoints(int points)
        {
            var result = Progression.AddExperience(points);
            var service = new TraitService();

            if (result.DidLevel)
            {
                Vitals.MaximumHealthPoints += HealthMultiplierWhenLevel * result.CurrentLevel;
                service.AddPoints(TraitPointsToUseWhenLevel, Traits);
            }
        }

        public int Strike()
        {
            // hämta strength och dexterity, kör en formula, smäll till
            return 0;
        }

        public bool AttemptAvoidStrike()
        {
            return true;
        }
    }
}
