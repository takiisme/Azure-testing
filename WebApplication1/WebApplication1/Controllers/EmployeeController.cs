using Communications.Requests;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _employeeService;

    public EmployeeController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }
    
    [HttpGet("datetime")]
    public IActionResult GetDatetime()
    {
        return Ok(DateTime.Now);
    }

    [HttpGet("getallEmployee")]
    public IActionResult GetAll()
    {
        return Ok("Get all");
    }

    [HttpPost("postallEmployee")]
    public async Task<IActionResult> PostAll(EmployeeAddRequest employeeAddRequest)
    {
        var (success, result) = await _employeeService.AddEmployee(employeeAddRequest.Id, employeeAddRequest.Name,
            employeeAddRequest.Gender, employeeAddRequest.Role);
        return Ok("Post all: " + employeeAddRequest.Id);
    }

    [HttpGet("getEmployee/{employeeID}")]
    public IActionResult GetEmployeeId([FromRoute] int MCPid)
    {
        return Ok("Get Employee: " + MCPid);
    }

    [HttpPost("postEmployee/{employeeID}")]
    public async Task<IActionResult> PostEmployeeId(EmployeeAddRequest employeeAddRequest, [FromRoute] int employeeID)
    {
        var (success, result) = await _employeeService.AddEmployee(employeeID, employeeAddRequest.Name,
            employeeAddRequest.Gender, employeeAddRequest.Role);
        return Ok("Post id: " + employeeID);
    }

    [HttpDelete("deleteEmployee/{employeeID}")]
    public async Task<IActionResult> DeleteEmployeeId([FromRoute] int employeeID)
    {
        var (success, result) = await _employeeService.DeleteEmployee(employeeID);
        if (!success)
        {
            return Ok("Does not exist employee!");
        }
        return Ok("Delete id: " + employeeID);
    }
}