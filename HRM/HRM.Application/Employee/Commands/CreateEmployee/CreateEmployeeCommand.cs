using HRM.Application.Employee.DTOs;
using MediatR;

namespace HRM.Application.Employee.Commands.CreateEmployee
{
    public class CreateEmployeeCommand : IRequest<EmployeeDto>
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = string.Empty;

        public string LastName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string? PhoneNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public DateTime HireDate { get; set; }

        public decimal Salary { get; set; }

        public bool IsActive { get; set; } = true;

        public int DepartmentId { get; set; }

        public CreateEmployeeCommand(CreateEmployeeDto employeeDto)
        {
            Id = employeeDto.EmployeeId;
            FirstName = employeeDto.FirstName;
            LastName = employeeDto.LastName;
            Email = employeeDto.Email;
            PhoneNumber = employeeDto.PhoneNumber;
            DateOfBirth = employeeDto.DateOfBirth;
            HireDate = employeeDto.HireDate;
            Salary = employeeDto.Salary;
            IsActive = employeeDto.IsActive;
            DepartmentId = employeeDto.DepartmentId;
        }
    }
}