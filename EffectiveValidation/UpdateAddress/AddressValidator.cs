using FluentValidation;
using System.Linq;

namespace EffectiveValidation.UpdateAddress
{
    public class AddressValidator : AbstractValidator<IAddress>
    {
        public AddressValidator()
        {
            RuleFor(a => a.AddressLine1)
                .NotEmpty().WithMessage("Required")
                .MaximumLength(25).WithMessage("Must not exceed 25 characters");

            RuleFor(a => a.AddressLine2)
                .MaximumLength(25).WithMessage("Must not exceed 25 characters");

            RuleFor(a => a.City)
                .NotEmpty().WithMessage("Required")
                .MaximumLength(25).WithMessage("Must not exceed 25 characters");

            RuleFor(a => a.State)
                .NotEmpty().WithMessage("Required")
                .Length(2).WithMessage("Must be 2 characters");

            RuleFor(a => a.ZipCode)
                .NotEmpty().WithMessage("Required")
                .Length(5).WithMessage("Must be 5 characters")
                .Must(z => z.All(char.IsDigit)).WithMessage("Must contain all numeric digits");
        }
    }
}
