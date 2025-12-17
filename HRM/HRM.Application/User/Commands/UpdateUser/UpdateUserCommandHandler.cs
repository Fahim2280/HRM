using AutoMapper;
using HRM.Application.User.DTOs;
using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using BCrypt.Net;

namespace HRM.Application.User.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, UserOperationResult>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<UserOperationResult> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                return UserOperationResult.Failure($"User with ID {request.Id} not found.", 404);
            }

            // Check if username is being changed and if the new username already exists
            if (user.Username != request.Username)
            {
                var existingUser = await _userRepository.GetUserByUsernameAsync(request.Username);
                if (existingUser != null)
                {
                    return UserOperationResult.Failure($"User with username '{request.Username}' already exists.", 409);
                }
            }

            user.Username = request.Username;
            user.Email = request.Email;
            user.Country = request.Country;
            user.PhoneNumber = request.PhoneNumber;
            user.Role = request.Role;
            user.IsActive = request.IsActive;
            user.ModifiedDate = DateTime.UtcNow;

            // Only update password if provided
            if (!string.IsNullOrEmpty(request.Password))
            {
                user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);
            }

            var updatedUser = await _userRepository.UpdateAsync(user);
            var userDto = _mapper.Map<UserDto>(updatedUser);

            return UserOperationResult.Success(userDto);
        }
    }
}