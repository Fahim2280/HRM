using HRM.Application.User.DTOs;
using MediatR;

namespace HRM.Application.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserDto>
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string? Password { get; set; }
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

    }
}