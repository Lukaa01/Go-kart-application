using Marketing_system.BL.Contracts.DTO;
using Marketing_system.BL.Contracts.IService;
using Marketing_system.BL.Service;
using Microsoft.AspNetCore.Mvc;

namespace Marketing_system.Controllers
{
    [Route("api/employees")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<EmployeeDTO>> CreateEmployee([FromBody] EmployeeDTO employee)
        {
            var result = await _employeeService.CreateEmployee(employee);
            return result;
        }

        [HttpGet("get/{id:int}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployeeById(int id)
        {
            var result = await _employeeService.GetEmployeeById(id);
            return Ok(result);
        }

        [HttpGet("get-all")]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAllEmployees()
        {
            var result = await _employeeService.GetAllEmployees();
            return Ok(result);
        }

        [HttpPut("update")]
        public async Task<ActionResult<EmployeeDTO>> UpdateEmployee([FromBody] EmployeeDTO employee)
        {
            var result = await _employeeService.UpdateEmployee(employee);
            if (result == null)
            {
                return BadRequest("Employee could not be updated");
            }
            return Ok(result);
        }
    }
}
