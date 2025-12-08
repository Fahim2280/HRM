using HRM.Application.Department.DTOs;
using MediatR;

namespace HRM.Application.Department.Commands.UpdateDepartment
{
    public class UpdateDepartmentCommand : IRequest<DepartmentDto>
    {    
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }

        public UpdateDepartmentCommand(int id, string name, string? description, bool isActive)
        {
            Id = id;
            Name = name;
            Description = description;
            IsActive = isActive;
        }
    }
}