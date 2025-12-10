using HRM.Application.User.Commands.CreateUser;
using HRM.Application.User.Commands.DeleteUser;
using HRM.Application.User.Commands.UpdateUser;
using HRM.Application.User.DTOs;
using HRM.Application.User.Queries.GetAllUsers;
using HRM.Application.User.Queries.GetUserById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HRM.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDto>>> GetAllUsers()
        {
            var query = new GetAllUsersQuery();
            var users = await _mediator.Send(query);
            return Ok(users);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetUserById(int id)
        {
            var query = new GetUserByIdQuery(id);
            var user = await _mediator.Send(query);
            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var command = new CreateUserCommand(
                createUserDto.Username,
                createUserDto.Password,
                createUserDto.Role)
            {
                IsActive = createUserDto.IsActive
            };

            var user = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetUserById), new { id = user.Id }, user);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {
            if (id != updateUserDto.Id)
            {
                return BadRequest("User ID mismatch");
            }

            var command = new UpdateUserCommand
            {
                Id = updateUserDto.Id,
                Username = updateUserDto.Username,
                Password = updateUserDto.Password,
                Role = updateUserDto.Role,
                IsActive = updateUserDto.IsActive
            };

            var user = await _mediator.Send(command);
            return Ok(user);
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
