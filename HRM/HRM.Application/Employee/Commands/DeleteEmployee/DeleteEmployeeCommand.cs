using HRM.Application.Common;
using MediatR;

namespace HRM.Application.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommand : IRequest<DeleteResult>
    {
        public int Id { get; set; }

        public DeleteEmployeeCommand(int id)
        {
            Id = id;
        }
    }
}