using HRM.Application.Common;
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