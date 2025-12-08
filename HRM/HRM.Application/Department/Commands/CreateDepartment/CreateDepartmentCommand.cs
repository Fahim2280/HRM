using HRM.Application.Department.DTOs;
using MediatR;

namespace HRM.Application.Department.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<DepartmentDto>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public CreateDepartmentCommand(string name, string? description)
        {
            Name = name;
            Description = description;
        }
    }
}