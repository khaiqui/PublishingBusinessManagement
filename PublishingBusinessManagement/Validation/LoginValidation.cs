using FluentValidation;
using PublishingBusinessManagement.DTOs;

namespace PublishingBusinessManagement.Validation
{
    public class LoginValidation : AbstractValidator<LoginDTO>
    {
        public LoginValidation()
        {
            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage("User Name is required.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required.");
        }
    }
}
