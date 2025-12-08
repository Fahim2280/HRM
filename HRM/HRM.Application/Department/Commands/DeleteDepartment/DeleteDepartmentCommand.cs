using MediatR;

namespace HRM.Application.Department.Commands.DeleteDepartment
{
    public class DeleteDepartmentCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteDepartmentCommand(int id)
        {
            Id = id;
        }
    }
}