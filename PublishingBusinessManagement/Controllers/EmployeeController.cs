using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PublishingBusinessManagement.Helpers;
using PublishingBusinessManagement.Models;
using PublishingBusinessManagement.Repositories.UnitOfWork;
using PublishingBusinessManagement.Services;
using System.Linq.Expressions;

namespace PublishingBusinessManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> GetAllEmployees(
            string? filter = null,
            string? sortBy = null,
            bool ascending = true,
            int pageIndex = 1,
            int pageSize = 10)
        {
            var employees = await _employeeService.GetAllEmployeesAsync(
                filter,
                sortBy,
                ascending,
                pageIndex,
                pageSize
            );

            return Ok(employees);
        }


        [HttpGet("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> GetEmployeeById(string id)
        {
            var employee = await _employeeService.GetEmployeeByIdAsync(id);
            return Ok(employee);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            if (employee == null)
            {
                return BadRequest(new { error = "Employee object is null" });
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _employeeService.AddEmployeeAsync(employee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = employee.EmpId }, employee);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> UpdateEmployee(string id, [FromBody] Employee employee)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            employee.EmpId = id;
            await _employeeService.UpdateEmployeeAsync(employee);
            return NoContent();
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = AppRole.Admin)]
        public async Task<IActionResult> DeleteEmployee(string id)
        {
            await _employeeService.DeleteEmployeeAsync(id);
            return NoContent();
        }




    }
}
