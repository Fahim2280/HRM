using HRM.Application.User.DTOs;
using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace HRM.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, DeleteResult>
    {
        private readonly IUserRepository _userRepository;

        public DeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<DeleteResult> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByIdAsync(request.Id);
            if (user == null)
            {
                return DeleteResult.Failure($"User with ID {request.Id} not found.", 404);
            }

            var result = await _userRepository.DeleteAsync(user);
            return DeleteResult.Success();
        }
    }
}