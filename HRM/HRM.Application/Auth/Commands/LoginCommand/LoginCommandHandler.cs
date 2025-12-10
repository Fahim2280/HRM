using HRM.Application.Auth.DTOs;
using HRM.Application.Auth.Services;
using HRM.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BCrypt.Net;

namespace HRM.Application.Auth.Commands.LoginCommand
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, AuthResponseDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<AuthResponseDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Get user by username
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user == null)
            {
                throw new Exception("Invalid username or password.");
            }

            // Verify password
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isValidPassword)
            {
                throw new Exception("Invalid username or password.");
            }

            // Generate JWT token
            var token = _authService.GenerateJwtToken(user);

            return new AuthResponseDto
            {
                Token = token,
                Username = user.Username,
                Role = user.Role,
                Expiration = DateTime.UtcNow.AddHours(1) // Token expires in 1 hour
            };
        }
    }
}