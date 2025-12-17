using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HRM.Application.User.DTOs
{
    public class UserDto
    {
        public int UserId { get; set; }

        [Required(ErrorMessage = "Username is required")]
        [StringLength(50, ErrorMessage = "Username must be between 1 and 50 characters", MinimumLength = 1)]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, ErrorMessage = "Password must be between 6 and 100 characters", MinimumLength = 6)]
        public string? Password { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [StringLength(50, ErrorMessage = "Role must be between 1 and 50 characters", MinimumLength = 1)]
        public string Role { get; set; } = string.Empty;

        public bool IsActive { get; set; }

        public DateTime CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }
    }
}