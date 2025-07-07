using DealManagement.Server.Resources;
using FluentValidation;

namespace DealManagement.Server.Domain.Validators
{
    public class DealValidator : AbstractValidator<SaveDealResource>
    {
        public DealValidator() {
            RuleFor(d => d.Slug)
                .NotEmpty().WithMessage("Deal slug is required.");
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Deal name is required.");

            // TODO: Add more validation rules as needed
        }
    }
}
