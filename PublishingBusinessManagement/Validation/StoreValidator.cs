using FluentValidation;
using PublishingBusinessManagement.Models;

namespace PublishingBusinessManagement.Validation
{
    public class StoreValidator : AbstractValidator<Store>
    {
        public StoreValidator()
        {
            RuleFor(store => store.StorId)
                .NotEmpty().WithMessage("Store ID is required.")
                .Length(4).WithMessage("Store ID must be exactly 4 characters long.");

            RuleFor(store => store.StorName)
                .MaximumLength(40).WithMessage("Store Name cannot be longer than 40 characters.");

            RuleFor(store => store.StorAddress)
                .MaximumLength(40).WithMessage("Store Address cannot be longer than 40 characters.");

            RuleFor(store => store.City)
                .MaximumLength(20).WithMessage("City cannot be longer than 20 characters.");

            RuleFor(store => store.State)
                .Length(2).WithMessage("State must be exactly 2 characters long.");

            RuleFor(store => store.Zip)
                .Length(5).WithMessage("Zip Code must be exactly 5 characters long.");
        }
    }
}
