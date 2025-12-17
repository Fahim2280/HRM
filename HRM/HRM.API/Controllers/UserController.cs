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
        [Authorize(Roles = "Administrator")]
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
            
            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }
            
            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<UserDto>> CreateUser([FromBody] CreateUserDto createUserDto)
        {
            var command = new CreateUserCommand
            {
                Username = createUserDto.Username,
                Email = createUserDto.Email,
                Country = createUserDto.Country,
                PhoneNumber = createUserDto.PhoneNumber,            
                Password = createUserDto.Password,
                Role = createUserDto.Role,
                IsActive = createUserDto.IsActive
            };

            var result = await _mediator.Send(command);
            
            if (result.IsSuccess)
            {
                return CreatedAtAction(nameof(GetUserById), new { id = result.User.Id }, result.User);
            }
            else
            {
                if (result.StatusCode == 409)
                {
                    return Conflict(new { Message = result.ErrorMessage });
                }
                return BadRequest(new { Message = result.ErrorMessage });
            }
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
                Email = updateUserDto.Email,
                Country = updateUserDto.Country,
                PhoneNumber = updateUserDto.PhoneNumber,
                Password = updateUserDto.Password,
                Role = updateUserDto.Role,
                IsActive = updateUserDto.IsActive
            };

            var result = await _mediator.Send(command);
            
            if (result.IsSuccess)
            {
                return Ok(result.User);
            }
            else
            {
                if (result.StatusCode == 404)
                {
                    return NotFound(new { Message = result.ErrorMessage });
                }
                else if (result.StatusCode == 409)
                {
                    return Conflict(new { Message = result.ErrorMessage });
                }
                return BadRequest(new { Message = result.ErrorMessage });
            }
        }


        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> DeleteUser(int id)
        {
            var command = new DeleteUserCommand(id);
            var result = await _mediator.Send(command);
            
            if (result.IsSuccess)
            {
                return Ok(true);
            }
            else
            {
                if (result.StatusCode == 404)
                {
                    return NotFound(new { Message = result.ErrorMessage });
                }
                return BadRequest(new { Message = result.ErrorMessage });
            }
        }
    }
}
