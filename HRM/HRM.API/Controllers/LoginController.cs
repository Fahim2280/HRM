using HRM.Application.Auth.Commands.LoginCommand;
using HRM.Application.Auth.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult> Login([FromBody] LoginDto loginDto)
        {
            var command = new LoginCommand
            {
                Identifier = loginDto.Identifier,
                Password = loginDto.Password
            };

            var result = await _mediator.Send(command);

            if (result.IsSuccess)
            {
                return Ok(new AuthResponseDto
                {
                    Token = result.Token,
                    Username = result.Username,
                    Role = result.Role,
                    Expiration = result.Expiration ?? DateTime.UtcNow.AddHours(1)
                });
            }
            else
            {
                return Unauthorized(new { Message = result.ErrorMessage });
            }
        }

        [HttpPost("logout")]
        public IActionResult Logout()
        {
            // For JWT-based authentication, logout is primarily a client-side operation
            // where the client discards the token. This endpoint can be called for
            // logging purposes or to perform any server-side cleanup if needed.
            // The token is expected to be sent in the Authorization header.
            return Ok(new { Message = "Successfully logged out" });
        }
    }
}