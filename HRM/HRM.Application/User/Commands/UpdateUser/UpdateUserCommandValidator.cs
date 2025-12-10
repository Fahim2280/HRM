using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.Application.User.Commands.UpdateUser
{
    public class UpdateUserCommandValidator : AbstractValidator<UpdateUserCommand>
    {
        public UpdateUserCommandValidator() 
        {
            RuleFor(x => x.Id)
                 .GreaterThan(0).WithMessage("User ID must be greater than 0");

            RuleFor(x => x.Username)
                .NotEmpty().WithMessage("Username is required")
                .MaximumLength(50).WithMessage("Username must not exceed 50 characters");

            RuleFor(x => x.Password)
                .MaximumLength(100).WithMessage("Password must not exceed 100 characters")
                .MinimumLength(6).When(x => !string.IsNullOrEmpty(x.Password))
                .WithMessage("Password must be at least 6 characters");

            RuleFor(x => x.Role)
                .NotEmpty().WithMessage("Role is required")
                .MaximumLength(50).WithMessage("Role must not exceed 50 characters");
        }
    }
}
