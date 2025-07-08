using DealManagement.Server.Resources;
using FluentValidation;

namespace DealManagement.Server.Domain.Validators
{
    public class PutDealValidator : AbstractValidator<DealResource>
    {
        public PutDealValidator()
        {
            RuleFor(d => d.Slug)
                .NotEmpty().WithMessage("Deal slug is required.");
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Deal name is required.");
        }
    }
}
