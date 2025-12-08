using MediatR;

namespace HRM.Application.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
    }
}