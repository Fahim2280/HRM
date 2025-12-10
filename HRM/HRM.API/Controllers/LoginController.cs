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
        public async Task<ActionResult<AuthResponseDto>> Login([FromBody] LoginDto loginDto)
        {
            var command = new LoginCommand
            {
                Username = loginDto.Username,
                Password = loginDto.Password
            };

            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
