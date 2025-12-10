using HRM.Application.Auth.DTOs;
using MediatR;

namespace HRM.Application.Auth.Commands.LoginCommand
{
    public class LoginCommand : IRequest<AuthResponseDto>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;

        public LoginCommand()
        {
        }
    }
}