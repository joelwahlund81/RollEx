using RollEx.Extensions;

namespace RollEx.Models
{
    public class CharacterTrait
    {
        public string Type => TypeOfTrait.GetEnumDescription();

        public int Points => points;

        private TypeOfTrait TypeOfTrait { get; set; }

        private int points { get; set; }

        public void SetPoints(int value)
        {
            points = value;
        }

        public CharacterTrait()
        {

        }

        public CharacterTrait(TypeOfTrait typeOfTrait, int points)
        {
            this.TypeOfTrait = typeOfTrait;
            this.SetPoints(points);
        }
    }
}
