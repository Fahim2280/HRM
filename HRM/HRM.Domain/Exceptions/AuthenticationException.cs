using System;

namespace HRM.Domain.Exceptions
{
    /// <summary>
    /// Exception thrown when authentication fails due to invalid credentials
    /// </summary>
    public class AuthenticationException : Exception
    {
        public AuthenticationException() : base("Invalid username or password.")
        {
        }

        public AuthenticationException(string message) : base(message)
        {
        }

        public AuthenticationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}