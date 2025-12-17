using AutoMapper;
using HRM.Application.User.DTOs;
using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BCrypt.Net;

namespace HRM.Application.User.Commands.CreateUser
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, UserOperationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
            // Note: You might want to add a method to check email uniqueness in the repository
            // For now, we'll assume usernames are unique

            var user = new HRM.Domain.Entities.User
            {
                Username = request.Username,
                Email = request.Email,
                Country = request.Country,
                PhoneNumber = request.PhoneNumber,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
                Role = request.Role,
                IsActive = request.IsActive,
                CreatedDate = DateTime.UtcNow
            };

            var createdUser = await _userRepository.AddAsync(user);
            var userDto = _mapper.Map<UserDto>(createdUser);

            return UserOperationResult.Success(userDto, 201);
        }
    }
}