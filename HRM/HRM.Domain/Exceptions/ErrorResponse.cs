using System;
using System.Collections.Generic;
using System.Text;

namespace HRM.Domain.Exceptions
{
    public class ErrorResponse
    {
        public string Message { get; set; } = string.Empty;
        public string? Details { get; set; }
    }
}
