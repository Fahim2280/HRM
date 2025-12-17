using HRM.Application.Department.Commands.CreateDepartment;
using HRM.Application.Department.Commands.DeleteDepartment;
using HRM.Application.Department.Commands.UpdateDepartment;
using HRM.Application.Department.DTOs;
using HRM.Application.Department.Queries.GetAllDepartments;
using HRM.Application.Department.Queries.GetDepartmentById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace HRM.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]

    public class DepartmentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentDto>>> GetDepartments()
        {
            try
            {
                var query = new GetAllDepartmentsQuery();
                var departments = await _mediator.Send(query);
                return Ok(departments);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetDepartment(int id)
        {
            try
            {
                var query = new GetDepartmentByIdQuery(id);
                var department = await _mediator.Send(query);
                if (department == null)
                {
                    return NotFound($"Department with ID {id} not found.");
                }
                return Ok(department);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentDto>> CreateDepartment([FromBody] DepartmentDto departmentDto)
        {
            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var command = new CreateDepartmentCommand(departmentDto.Name, departmentDto.Description);
                var department = await _mediator.Send(command);
                return CreatedAtAction(nameof(GetDepartment), new { id = department.Id }, department);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentDto departmentDto)
        {
            // Check if the model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var command = new UpdateDepartmentCommand(id, departmentDto.Name, departmentDto.Description, departmentDto.IsActive);
                var department = await _mediator.Send(command);
                return Ok(department);
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
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            try
            {
                var command = new DeleteDepartmentCommand(id);
                var result = await _mediator.Send(command);
                if (!result)
                {
                    return NotFound($"Department with ID {id} not found.");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}