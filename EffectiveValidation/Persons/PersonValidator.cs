using FluentValidation;

namespace EffectiveValidation.Persons
{
    public class PersonValidator : AbstractValidator<IPerson>
    {
        public PersonValidator()
        {
            RuleFor(p => p.FullName)
                .MinimumLength(3)
                .MaximumLength(50);
        }
    }
}
