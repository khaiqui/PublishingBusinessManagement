using FluentValidation;
using PublishingBusinessManagement.Models;

namespace PublishingBusinessManagement.Validation
{
    public class TitleValidator : AbstractValidator<Title>
    {
        public TitleValidator()
        {
            RuleFor(title => title.TitleId)
                .NotEmpty().WithMessage("Title ID is required.")
                .MaximumLength(50).WithMessage("Title ID cannot be longer than 50 characters.");

            RuleFor(title => title.Title1)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(80).WithMessage("Title cannot be longer than 80 characters.");

            RuleFor(title => title.Type)
                .NotEmpty().WithMessage("Type is required.")
                .Length(12).WithMessage("Type must be exactly 12 characters long.");

            RuleFor(title => title.PubId)
                .Length(4).WithMessage("Publisher ID must be exactly 4 characters long.");

            RuleFor(title => title.Price)
                .GreaterThan(0).WithMessage("Price must be greater than 0.");

            RuleFor(title => title.Advance)
                .GreaterThan(0).WithMessage("Advance must be greater than 0.");

            RuleFor(title => title.Royalty)
                .GreaterThanOrEqualTo(0).WithMessage("Royalty must be 0 or greater.");

            RuleFor(title => title.YtdSales)
                .GreaterThanOrEqualTo(0).WithMessage("YTD Sales must be 0 or greater.");

            RuleFor(title => title.Pubdate)
                .NotEmpty().WithMessage("Publication date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Publication date cannot be in the future.");
        }
    }
}
