using HRM.Application.Employee.DTOs;
using MediatR;

namespace HRM.Application.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; } = true;

        public int DepartmentId { get; set; }
    }
}