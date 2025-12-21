using AutoMapper;
using HRM.Application.User.DTOs;
using HRM.Domain.Interfaces;
using MediatR;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading;
using System.Threading.Tasks;
using UserEntity = HRM.Domain.Entities.User;

namespace HRM.Application.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserOperationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IEmailRepository _emailService;
        private readonly IConfiguration _configuration;

        public CreateUserCommandHandler(
            IUserRepository userRepository,
            IMapper mapper,
            IEmailRepository emailService,
            IConfiguration configuration)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _emailService = emailService;
            _configuration = configuration;
        }

        public async Task<UserOperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            // Check if user already exists
            var existingUser = await _userRepository.GetUserByUsernameAsync(request.Username);
            if (existingUser != null)
            {
                return UserOperationResult.Failure($"User with username '{request.Username}' already exists.", 409);
            }

            // Check if email already exists
            var existingUserByEmail = await _userRepository.GetUserByEmailAsync(request.Email);
            if (existingUserByEmail != null)
            {
                return UserOperationResult.Failure($"User with email '{request.Email}' already exists.", 409);
            }

            // Generate email verification token
            var verificationToken = Guid.NewGuid().ToString();
            var tokenExpiry = DateTime.UtcNow.AddHours(24);

            var user = _mapper.Map<UserEntity>(request);

            // Set properties that need special handling
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            user.EmailVerificationToken = verificationToken;
            user.EmailVerificationTokenExpiry = tokenExpiry;

            var createdUser = await _userRepository.AddAsync(user);
            var userDto = _mapper.Map<UserDto>(createdUser);

            // Send verification email
            await SendVerificationEmail(createdUser);

            return UserOperationResult.Success(userDto, 201);
        }

        private async Task SendVerificationEmail(UserEntity user)
        {
            var baseUrl = _configuration["AppSettings:BaseUrl"] ?? "http://localhost:5023";
            var alternativeBaseUrl = _configuration["AppSettings:AlternativeBaseUrl"];

            var verificationLink = $"{baseUrl}/api/user/verify-email?token={user.EmailVerificationToken}";
            var alternativeVerificationLink = !string.IsNullOrEmpty(alternativeBaseUrl)
                ? $"{alternativeBaseUrl}/api/user/verify-email?token={user.EmailVerificationToken}"
                : null;

            var bodyContent = $@"
                <h2>Welcome to HRM!</h2>
                <p>Please click one of the links below to verify your email address:</p>
                <p><a href='{verificationLink}'>{verificationLink}</a></p>";

            if (!string.IsNullOrEmpty(alternativeVerificationLink))
            {
                bodyContent += $@"<p><a href='{alternativeVerificationLink}'>{alternativeVerificationLink}</a></p>";
            }

            bodyContent += $@"
                <p>This link will expire in 24 hours.</p>
                <p>If you didn't create an account, you can ignore this email.</p>";

            var subject = "Verify your email address";

            await _emailService.SendEmailAsync(user.Email, subject, bodyContent);
        }
    }
}