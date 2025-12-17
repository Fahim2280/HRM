using HRM.Application.User.DTOs;
using MediatR;

namespace HRM.Application.User.Commands.UpdateUser
{
    public class UpdateUserCommand : IRequest<UserOperationResult>
    {
        public int Id { get; set; }
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string? Password { get; set; }
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}