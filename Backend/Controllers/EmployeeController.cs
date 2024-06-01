

using BALayer.Interfaces;
using DALayer.DTOs;
using DALayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace crud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IService<Employee> _employeeService;
        public EmployeeController(IService<Employee> employeeService)
        {
            _employeeService = employeeService;
        }


        [HttpGet("GetAllEmployees")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            try
            {
                var data = await _employeeService.GetAll();
                if (data == null || !data.Any())
                {
                    return NotFound("No data found");
                }

                return Ok(data);
            }
            catch(Exception ex)
            {
                throw new Exception("An unexpected error occurred, Message : ", ex);
            }
        }

        [HttpGet("GetEmployeeById/{id}")]
        public async Task<ActionResult<Employee>> GetEmployeeById(int id)
        {
            try
            {
                var result = await _employeeService.GetById(id);

                if (result == null)
                {
                    var message = $"Employee ID {id} not found";
                    return NotFound(message);
                }

                return Ok(result);
            }
            catch(Exception ex)
            {
                return StatusCode(500, new { message = $"An unexpected error occurred, Message = {ex}" });
            }
        }

        [HttpPost("CreateEmployee")]
        public async Task<ActionResult<Employee>> CreateEmployee(EmployeeRequestDto empDto)
        {
           
            var newEmployee = new Employee()
            {
                EmpName = empDto.EmpName,
                Email = empDto.Email,
                Gender = empDto.Gender,
                PhoneNumber = empDto.PhoneNumber
            };

            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(newEmployee);
                }

                var data = await _employeeService.Create(newEmployee);

                var result = new EmployeeResponseDto(newEmployee);

                return Ok(new { message = $"Data inserted successfully!!", Employee = result });
            }
            catch(Exception ex)
            {
                throw new Exception($"An unexpected error occurred, {ex}");
            }
        }

        [HttpPut("UpdateEmp/{id}")]
        public async Task<ActionResult<Employee>> UpdateEmp(int id, Employee emp)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(emp);
                }

                var result = await _employeeService.Update(id, emp);
                return Ok(new { message = $"Entity Updated Successfully!!", UpdatedData = result } );
            }
            catch(Exception ex)
            {
                throw new Exception($"An unexpected error occerred, Message : {ex}");
            }
        }

        [HttpDelete("DeleteEmployee/{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            try
            {
                await _employeeService.Delete(id);
                return Ok(new {message = $"Employee ID {id} deleted successfully!!"});
            }
            catch(Exception ex)
            {
                throw new Exception($"An unexpected error occurred, Message = {ex}");
            }
        }
    }
}
