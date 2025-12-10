using HRM.Application.User.DTOs;
using MediatR;

namespace HRM.Application.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserDto>
    {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public CreateUserCommand(string username, string password, string role)
        {
            Username = username;
            Password = password;
            Role = role;
        }
    }
}