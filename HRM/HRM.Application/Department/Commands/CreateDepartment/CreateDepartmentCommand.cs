using HRM.Application.Department.DTOs;
using MediatR;

namespace HRM.Application.Department.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<DepartmentDto>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; } = true;

        public CreateDepartmentCommand(CreatedDepartmentDto departmentDto)
        {
            Name = departmentDto.Name;
            Description = departmentDto.Description;
            IsActive = departmentDto.IsActive;
        }
    }
}