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
    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IAuthService _authService;

        public LoginCommandHandler(IUserRepository userRepository, IAuthService authService)
        {
            _userRepository = userRepository;
            _authService = authService;
        }

        public async Task<LoginResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            // Get user by username or email
            var user = await GetUserByIdentifierAsync(request.Identifier);
            if (user == null)
            {
                return LoginResult.Failure("Invalid identifier or password.");
            }

            // Verify password
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isValidPassword)
            {
                return LoginResult.Failure("Invalid identifier or password.");
            }

            // Check if email is verified
            if (!user.IsEmailVerified)
            {
                return LoginResult.Failure("You should verify/confirm the email.");
            }

            // Generate JWT token
            var token = _authService.GenerateJwtToken(user);
            
            // Set expiration time to 1 hour from now
            var expirationTime = DateTime.UtcNow.AddHours(1);

            return LoginResult.Success(token, user.Username, user.Role, expirationTime);
        }

        private async Task<HRM.Domain.Entities.User?> GetUserByIdentifierAsync(string identifier)
        {
            // Check if identifier is an email
            if (identifier.Contains("@"))
            {
                return await _userRepository.GetUserByEmailAsync(identifier);
            }
            else
            {
                return await _userRepository.GetUserByUsernameAsync(identifier);
            }
        }
    }
}