using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HRM.API.Middleware
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Log user information if authenticated
            if (context.User.Identity?.IsAuthenticated == true)
            {
                var userId = context.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
                var username = context.User.FindFirst(ClaimTypes.Name)?.Value;
                var role = context.User.FindFirst(ClaimTypes.Role)?.Value;

                // Add user info to context items for use in controllers
                context.Items["UserId"] = userId;
                context.Items["Username"] = username;
                context.Items["Role"] = role;
            }

            // Call the next middleware in the pipeline
            await _next(context);
        }
    }
}