using FluentValidation;

namespace HRM.Application.Department.Commands.CreateDepartment
{
    public class CreateDepartmentCommandValidator : AbstractValidator<CreateDepartmentCommand>
    {
        public CreateDepartmentCommandValidator()
        {           
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Department name is required")
                .MaximumLength(100).WithMessage("Department name must not exceed 100 characters");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Department description is required")
                .MaximumLength(500).WithMessage("Department description must not exceed 500 characters");
        }
    }
}