using FluentValidation;
using PublishingBusinessManagement.Models;

namespace PublishingBusinessManagement.Validation
{
    public class EmployeeValidator : AbstractValidator<Employee>
    {
        public EmployeeValidator()
        {
            RuleFor(emp => emp.EmpId)
                .Matches(@"^[A-Z]{3}[1-9][0-9]{4}[FM]$|^[A-Z]-[A-Z][1-9][0-9]{4}[FM]$")
                .WithMessage("EmpId must be in the format 'AAA1234567F' or 'A-B1234567F'.");

            RuleFor(emp => emp.Fname)
                .NotEmpty().WithMessage("First name is required.")
                .MaximumLength(20).WithMessage("First name cannot be longer than 20 characters.");

            RuleFor(emp => emp.Lname)
                .NotEmpty().WithMessage("Last name is required.")
                .MaximumLength(30).WithMessage("Last name cannot be longer than 30 characters.");

            RuleFor(emp => (int)emp.JobId)
                .GreaterThan(0).WithMessage("Job ID must be greater than 0.");

            RuleFor(emp => emp.PubId)
                .NotEmpty().WithMessage("Publisher ID is required.")
                .Length(4).WithMessage("Publisher ID must be exactly 4 characters long.");

            RuleFor(emp => emp.HireDate)
                .NotEmpty().WithMessage("Hire date is required.")
                .LessThanOrEqualTo(DateTime.Now).WithMessage("Hire date cannot be in the future.");
        }
    }
}
