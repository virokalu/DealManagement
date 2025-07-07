using DealManagement.Server.Domain.Models;
using FluentValidation;

namespace DealManagement.Server.Domain.Validators
{
    public class HotelValidator : AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(h => h.Name)
                .NotEmpty().WithMessage("Hotel name is required.");
            RuleFor(h => h.Rate)
                .InclusiveBetween(1.0m, 5.0m).WithMessage("Rate must be between 1.0 and 5.0.");
            RuleFor(h => h.DealSlug)
                .NotEmpty().WithMessage("Deal slug is required.");
        }
    }
}
