using FluentValidation;

namespace DealManagement.Server.Models.Validators
{
    public class HotelValidator : AbstractValidator<Hotel>
    {
        public HotelValidator()
        {
            RuleFor(h => h.Name)
                .NotEmpty().WithMessage("Hotel name is required.")
                .MaximumLength(100).WithMessage("Hotel name cannot exceed 100 characters.");
            RuleFor(h => h.Rate)
                .InclusiveBetween(1.0m, 5.0m).WithMessage("Rate must be between 1.0 and 5.0.");
            RuleFor(h => h.DealSlug)
                .NotEmpty().WithMessage("Deal slug is required.");
        }
    }
}
