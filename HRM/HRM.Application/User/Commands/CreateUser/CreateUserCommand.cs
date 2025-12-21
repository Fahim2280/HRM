using HRM.Application.User.DTOs;
using MediatR;

namespace HRM.Application.User.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<UserOperationResult>
    {
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string ConfirmPassword { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; } = true;

        public CreateUserCommand(CreateUserDto userDto)
        {
            Username = userDto.Username;
            Email = userDto.Email;
            Country = userDto.Country;
            PhoneNumber = userDto.PhoneNumber;
            Password = userDto.Password;
            ConfirmPassword = userDto.ConfirmPassword;
            Role = userDto.Role;
            IsActive = userDto.IsActive;
        }
    }    
}