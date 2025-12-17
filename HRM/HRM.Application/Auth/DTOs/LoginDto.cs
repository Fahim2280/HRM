using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.Application.Auth.DTOs
{
    public class LoginDto
    {
        public string Identifier { get; set; } = string.Empty; // Can be username or email
        public string Password { get; set; } = string.Empty;
    }
}