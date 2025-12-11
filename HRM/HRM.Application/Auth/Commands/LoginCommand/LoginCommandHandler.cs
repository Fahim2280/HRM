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
            // Get user by username
            var user = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (user == null)
            {
                return LoginResult.Failure("Invalid username or password.");
            }

            // Verify password
            bool isValidPassword = BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash);
            if (!isValidPassword)
            {
                return LoginResult.Failure("Invalid username or password.");
            }

            // Generate JWT token
            var token = _authService.GenerateJwtToken(user);

            return LoginResult.Success(token, user.Username, user.Role, DateTime.UtcNow.AddHours(1));
        }
    }
}