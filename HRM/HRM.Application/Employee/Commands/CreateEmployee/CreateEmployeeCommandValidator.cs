using FluentValidation;

namespace HRM.Application.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommandValidator : AbstractValidator<CreateEmployeeCommand>
    {
        public CreateEmployeeCommandValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name is required")
                .MaximumLength(50).WithMessage("First name must be between 1 and 50 characters");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name is required")
                .MaximumLength(50).WithMessage("Last name must be between 1 and 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.PhoneNumber)
                .MaximumLength(20).WithMessage("Phone number must not exceed 20 characters");

            RuleFor(x => x.DateOfBirth)
                .NotEmpty().WithMessage("Date of birth is required");

            RuleFor(x => x.HireDate)
                .NotEmpty().WithMessage("Hire date is required");

            RuleFor(x => x.Salary)
                .GreaterThan(0).WithMessage("Salary must be a positive value");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Department ID must be a positive integer");
        }
    }
}