using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.Application.Auth.DTOs
{
    public class AuthResponseDto
    {
        public string Token { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public DateTime Expiration { get; set; }
    }
}
