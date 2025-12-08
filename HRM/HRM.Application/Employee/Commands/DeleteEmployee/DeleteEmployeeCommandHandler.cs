using HRM.Domain.Entities;
using HRM.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmployeeEntity = HRM.Domain.Entities.Employee;

namespace HRM.Application.Employee.Commands.DeleteEmployee
{
    public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        private readonly IEmployeeRepository _employeeRepository;


        public DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return false;
            }

            return await _employeeRepository.DeleteAsync(employee);
        }
    }
}