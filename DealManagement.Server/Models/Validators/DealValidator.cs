using FluentValidation;

namespace DealManagement.Server.Models.Validators
{
    public class DealValidator : AbstractValidator<Deal>
    {
        public DealValidator() {
            RuleFor(d => d.Slug)
                .NotEmpty().WithMessage("Deal slug is required.")
                .MaximumLength(100).WithMessage("Deal slug cannot exceed 100 characters.");
            RuleFor(d => d.Name)
                .NotEmpty().WithMessage("Deal name is required.")
                .MaximumLength(200).WithMessage("Deal name cannot exceed 200 characters.");
            RuleForEach(d => d.Hotels)
                .SetValidator(new HotelValidator());
        }
    }
}
