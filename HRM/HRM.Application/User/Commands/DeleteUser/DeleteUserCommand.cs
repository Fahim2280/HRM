using MediatR;

namespace HRM.Application.User.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteUserCommand(int id)
        {
            Id = id;
        }
        
        public DeleteUserCommand()
        {
        }
    }
}