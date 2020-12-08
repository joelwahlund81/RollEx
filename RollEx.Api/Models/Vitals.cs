using System.Text.Json.Serialization;

namespace RollEx.Models
{
    public class Vitals
    {
        [JsonPropertyName("max_hp")]
        public double MaximumHealthPoints { get => maximumHealthPoints; }
        private double maximumHealthPoints { get; set; }

        [JsonPropertyName("current_hp")]
        public double CurrentHealthPoints { get => currentHealthPoints; }
        private double currentHealthPoints { get; set; }

        public Vitals()
        {
            currentHealthPoints = 1000;
            maximumHealthPoints = 1000;
        }

        public void AddMaximumHealthPoints(int multiplier, int level)
        {
            this.maximumHealthPoints += multiplier * level;
        }

        public void SetHealth(double health)
        {
            this.currentHealthPoints = health;
        }
    }
}
