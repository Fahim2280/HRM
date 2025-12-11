using HRM.Application.User.DTOs;
using MediatR;

namespace HRM.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<DeleteResult>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }
}