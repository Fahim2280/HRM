using HRM.Application.Employee.DTOs;
using HRM.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using EmployeeEntity = HRM.Domain.Entities.Employee;

namespace HRM.Application.Employee.Queries.GetAllEmployee
{
    public class GetAllEmployeesQueryHandler : IRequestHandler<GetAllEmployeesQuery, IEnumerable<EmployeeDto>>
    {
        private readonly IEmployeeRepository _employeeRepository;

        public GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<EmployeeDto>> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            var employees = await _employeeRepository.GetAllAsync();
            var employeeDtos = new List<EmployeeDto>();

            foreach (var employee in employees)
            {
                employeeDtos.Add(new EmployeeDto
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
                });
            }

            return employeeDtos;
        }
    }
}