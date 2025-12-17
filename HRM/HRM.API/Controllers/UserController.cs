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
                ConfirmPassword = createUserDto.ConfirmPassword,
                Role = createUserDto.Role,
                IsActive = createUserDto.IsActive
            };
         
            var result = await _mediator.Send(command);
            try
            {
                if (result.IsSuccess && result.User != null)
                {
                    return CreatedAtAction(nameof(GetUserById), new { id = result.User.UserId }, result.User);
                }
                else
                {
                    return BadRequest(result.ErrorMessage ?? "User creation failed.");
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
           
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDto>> UpdateUser(int id, [FromBody] UpdateUserDto updateUserDto)
        {

            if (id != updateUserDto.Id)
            {
                return BadRequest("User ID mismatch");
            }
            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
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
                return Ok(result);
            }
            catch (ArgumentException ex) when (ex.Message.Contains("not found"))
            {
                return NotFound(ex.Message);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
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