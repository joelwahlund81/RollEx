using RollEx.Api.Models;
using RollEx.Extensions;
using RollEx.Services;
using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace RollEx.Models
{
    public class Hero
    {
        [JsonIgnore]
        public string FirstName { get; set; }
        [JsonIgnore]
        public string FamilyName { get; set; }
        [JsonIgnore]
        public bool OneWordName { get; set; }
        [JsonPropertyName("name")]
        public string GetName => $"{FirstName} {(OneWordName ? string.Empty : FamilyName) }".TrimEnd();

        [JsonIgnore]
        public Gender Gender { get; set; }
        [JsonPropertyName("gender")]
        public string DisplayGender => this.Gender.GetEnumDescription();

        [JsonIgnore]
        public Race Race { get; set; }
        [JsonPropertyName("race")]
        public string DisplayRace => this.Race.GetEnumDescription();

        [JsonPropertyName("vitals")]
        public Vitals Vitals { get; set; }

        [JsonPropertyName("progress")]
        public Progression Progression { get; set; }

        // TODO: Stature (Smal, muskulös, överviktig)
        [JsonPropertyName("physique")]
        public PhysicalAttributes PhysicalAttributes { get; set; }

        [JsonPropertyName("traits")]
        public Traits Traits { get; set; }

        private const int TraitPointsToUseWhenLevel = 10;
        private const int HealthMultiplierWhenLevel = 100;

        // ta fram bestämda värden för olika egenskaper baserat på värden från traits
        // exempel inom vilket omfång kan karaktären slå i styrka

        // kanske ska lägga egenskaperna för att generera saker via hjälten
        // exempelvis ha en metod på Hero som beräknar chansen att undvika slag
        // då hämtar den Trait för Dexterity och dess värde

        // Tagline
        // Nickname
        // Origin (city)
        public Hero()
        {

        }

        public Hero(GeneratedName generatedName)
        {
            FirstName = generatedName.FirstName;
            FamilyName = generatedName.LastName;
            OneWordName = generatedName.OneWordName;
            Gender = generatedName.Gender;
        }

        public Hero(GeneratedName generatedName, Race race, PhysicalAttributes physicalAttributes, Vitals vitals, Progression progression, Traits traits)
        {
            if (generatedName != null)
            {
                FirstName = generatedName.FirstName;
                FamilyName = generatedName.LastName;
                OneWordName = generatedName.OneWordName;
                Gender = generatedName.Gender;
            }

            Race = race;

            if (physicalAttributes != null)
            {
                PhysicalAttributes = physicalAttributes;
            }
            if (vitals != null)
            {
                Vitals = vitals;
            }
            if (progression != null)
            {
                Progression = progression;
            }
            if (traits != null)
            {
                Traits = traits;
            }
        }

        public void AddExperiencePoints(int points)
        {
            var (DidLevel, CurrentLevel) = Progression.AddExperience(points);

            if (DidLevel)
            {
                Vitals.AddMaximumHealthPoints(HealthMultiplierWhenLevel, CurrentLevel);
                Traits.AddPoints(TraitPointsToUseWhenLevel);
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
