using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.Application.Department.Commands.CreateDepartment
{
    public class CreateDepartmentCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
