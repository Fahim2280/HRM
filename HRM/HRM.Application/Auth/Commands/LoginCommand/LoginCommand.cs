using HRM.Application.Auth.DTOs;
using MediatR;

namespace HRM.Application.Auth.Commands.LoginCommand
{
    public class LoginCommand : IRequest<LoginResult>
    {
        public string Identifier { get; set; } = string.Empty; // Can be username or email
        public string Password { get; set; } = string.Empty;

        public LoginCommand()
        {
        }
    }
}