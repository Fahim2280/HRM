using HRM.Domain.Exceptions;
using System.Net;
using System.Text.Json;

namespace HRM.API.Middleware
{      
    public static class ExceptionHandlingMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlingMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}