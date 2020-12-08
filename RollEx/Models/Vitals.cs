namespace RollEx.Models
{
    public class Vitals
    {
        public double MaximumHealthPoints { get; set; }
        public double CurrentHealthPoints { get; set; }

        public Vitals()
        {
            CurrentHealthPoints = 1000;
            MaximumHealthPoints = 1000;
        }
    }
}
