using DealManagement.Server.Domain.Models;
using FluentValidation;

namespace DealManagement.Server.Domain.Validators
{
    public class DealValidator : AbstractValidator<Deal>
    {
        public DealValidator() {
            RuleFor(d => d.Slug)
                .NotEmpty().WithMessage("Deal slug is required.");
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Deal name is required.");
            RuleFor(d => d.Hotels).NotEmpty()
                .WithMessage("At least one hotel is required for a deal.");
            RuleForEach(d => d.Hotels)
                .SetValidator(new HotelValidator());
        }
    }
}
