using HRM.Application.Employee.DTOs;
using HRM.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using EmployeeEntity = HRM.Domain.Entities.Employee;

namespace HRM.Application.Employee.Queries.GetEmployeeById
{
    public class GetEmployeeByIdQueryHandler : IRequestHandler<GetEmployeeByIdQuery, EmployeeDto?>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<EmployeeDto?> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            var employee = await _employeeRepository.GetByIdAsync(request.Id);
            if (employee == null)
            {
                return null;
            }

            return new EmployeeDto
            {
                Id = employee.Id ?? 0,
                FirstName = employee.FirstName,
                LastName = employee.LastName,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                DateOfBirth = employee.DateOfBirth,
                HireDate = employee.HireDate,
                Salary = employee.Salary,
                IsActive = employee.IsActive,
                DepartmentId = employee.DepartmentId,
                CreatedDate = employee.CreatedDate,
                ModifiedDate = employee.ModifiedDate
            };
        }
    }
}