using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.Domain.Entities
{
    public class Employee
    {
        public int? Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? PhoneNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public DateTime? ModifiedDate { get; set; }

        // Foreign Key
        public int DepartmentId { get; set; }

        // Navigation property
        public Department Department { get; set; } = null!;
    }
}
