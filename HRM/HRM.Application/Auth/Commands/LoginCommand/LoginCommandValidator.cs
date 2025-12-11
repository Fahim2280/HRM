using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.Application.Auth.Commands.LoginCommand
{
    public class LoginCommandValidator : FluentValidation.AbstractValidator<LoginCommand>
    {
        public LoginCommandValidator() 
        {
            RuleFor(x => x.Username)
                  .NotEmpty().WithMessage("Username is required");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password is required");
        }
    }
}
