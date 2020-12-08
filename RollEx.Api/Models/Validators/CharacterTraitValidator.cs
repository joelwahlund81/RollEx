using FluentValidation;
using RollEx.Models;

namespace RollEx.Api.Models.Validators
{
    public class CharacterTraitValidator : AbstractValidator<CharacterTrait>
    {
        public CharacterTraitValidator()
        {
            RuleFor(x => x.Type).IsInEnum();
            RuleFor(x => x.Points).NotEmpty().InclusiveBetween(0, 40);
        }
    }
}
