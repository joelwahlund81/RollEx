using FluentValidation;
using RollEx.Models;

namespace RollEx.Api.Models.Validators
{
    public class HeroValidator : AbstractValidator<Hero>
    {
        public HeroValidator()
        {
            RuleFor(hero => hero.PhysicalAttributes.Height)
                .NotNull()
                .WithMessage("Height is required")
                .InclusiveBetween(50, 60)
                .WithMessage("Height is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Duck);
            RuleFor(hero => hero.PhysicalAttributes.Weight)
                .NotNull()
                .WithMessage("Weight is required")
                .InclusiveBetween(3, 7)
                .WithMessage("Weight is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Duck);

            RuleFor(hero => hero.PhysicalAttributes.Height)
                .NotNull()
                .WithMessage("Height is required")
                .InclusiveBetween(45, 55)
                .WithMessage("Height is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Fox);
            RuleFor(hero => hero.PhysicalAttributes.Weight)
                .NotNull()
                .WithMessage("Weight is required")
                .InclusiveBetween(4, 8)
                .WithMessage("Weight is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Fox);

            RuleFor(hero => hero.PhysicalAttributes.Height)
                .NotNull()
                .WithMessage("Height is required")
                .InclusiveBetween(190, 205)
                .WithMessage("Height is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Orc);
            RuleFor(hero => hero.PhysicalAttributes.Weight)
                .NotNull()
                .WithMessage("Weight is required")
                .InclusiveBetween(110, 130)
                .WithMessage("Weight is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Orc);

            RuleFor(hero => hero.PhysicalAttributes.Height)
                .NotNull()
                .WithMessage("Height is required")
                .InclusiveBetween(180, 195)
                .WithMessage("Height is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Elf);
            RuleFor(hero => hero.PhysicalAttributes.Weight)
                .NotNull()
                .WithMessage("Weight is required")
                .InclusiveBetween(75, 100)
                .WithMessage("Weight is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Elf);

            RuleFor(hero => hero.PhysicalAttributes.Height)
                .NotNull()
                .WithMessage("Height is required")
                .InclusiveBetween(120, 125)
                .WithMessage("Height is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Dwarf);
            RuleFor(hero => hero.PhysicalAttributes.Weight)
                .NotNull()
                .WithMessage("Weight is required")
                .InclusiveBetween(50, 90)
                .WithMessage("Weight is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Dwarf);

            RuleFor(hero => hero.PhysicalAttributes.Height)
                .NotNull()
                .WithMessage("Height is required")
                .InclusiveBetween(160, 200)
                .WithMessage("Height is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Human);
            RuleFor(hero => hero.PhysicalAttributes.Weight)
                .NotNull()
                .WithMessage("Weight is required")
                .InclusiveBetween(65, 125)
                .WithMessage("Weight is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Human);

            RuleFor(hero => hero.PhysicalAttributes.Height)
                .NotNull()
                .WithMessage("Height is required")
                .InclusiveBetween(70, 90)
                .WithMessage("Height is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Pig);
            RuleFor(hero => hero.PhysicalAttributes.Weight)
                .NotNull()
                .WithMessage("Weight is required")
                .InclusiveBetween(230, 360)
                .WithMessage("Weight is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Pig);

            RuleFor(hero => hero.PhysicalAttributes.Height)
                .NotNull()
                .WithMessage("Height is required")
                .InclusiveBetween(160, 200)
                .WithMessage("Height is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Zombie);
            RuleFor(hero => hero.PhysicalAttributes.Weight)
                .NotNull()
                .WithMessage("Weight is required")
                .InclusiveBetween(50, 100)
                .WithMessage("Weight is not within range")
                .When(hero => hero.PhysicalAttributes != null && hero.Race == Race.Zombie);

            RuleFor(hero => hero.Vitals.CurrentHealthPoints).NotEmpty().When(hero => hero.Vitals != null);

            RuleFor(hero => hero.Race).IsInEnum();

            RuleFor(hero => hero.Gender).IsInEnum();
        }
    }
}
