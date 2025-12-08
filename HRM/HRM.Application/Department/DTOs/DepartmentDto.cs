using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRM.Application.Department.DTOs
{
    public class DepartmentDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Department name is required")]
        [StringLength(100, ErrorMessage = "Department name must be between 1 and 100 characters", MinimumLength = 1)]
        public string Name { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Department description must not exceed 500 characters")]
        public string? Description { get; set; }

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}