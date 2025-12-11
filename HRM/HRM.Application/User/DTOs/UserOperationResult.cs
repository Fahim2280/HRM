using System;

namespace HRM.Application.User.DTOs
{

    public class UserOperationResult
    {

        public bool IsSuccess { get; set; }

        public UserDto? User { get; set; }

        public string? ErrorMessage { get; set; }

        public int StatusCode { get; set; }

     
        public static UserOperationResult Success(UserDto user, int statusCode = 200)
        {
            return new UserOperationResult
            {
                IsSuccess = true,
                User = user,
                StatusCode = statusCode
            };
        }

        public static UserOperationResult Failure(string errorMessage, int statusCode = 400)
        {
            return new UserOperationResult
            {
                IsSuccess = false,
                ErrorMessage = errorMessage,
                StatusCode = statusCode
            };
        }
    }
}