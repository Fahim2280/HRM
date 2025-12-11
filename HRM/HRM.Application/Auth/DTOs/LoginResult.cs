using System;

namespace HRM.Application.Auth.DTOs
{

    public class LoginResult
    {

        public bool IsSuccess { get; set; }

        public string? Token { get; set; }

        public string? Username { get; set; }

        public string? Role { get; set; }

        public DateTime? Expiration { get; set; }

        public string? ErrorMessage { get; set; }

        public static LoginResult Success(string token, string username, string role, DateTime expiration)
        {
            return new LoginResult
            {
                IsSuccess = true,
                Token = token,
                Username = username,
                Role = role,
                Expiration = expiration
            };
        }

        public static LoginResult Failure(string errorMessage)
        {
            return new LoginResult
            {
                IsSuccess = false,
                ErrorMessage = errorMessage
            };
        }
    }
}