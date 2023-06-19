using Communications.Requests;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace Controllers;

[ApiController]
[Route("[controller]")]
public class TaskController : ControllerBase
{
    private readonly ITaskService _taskService;

    public TaskController(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [HttpPost("add-task")]
    public async Task<IActionResult> AddTask(AddTaskRequest addTaskRequest)
    {
        var (success, result) =
            await _taskService.AddTask(addTaskRequest.Id, addTaskRequest.Date, addTaskRequest.WorkerId);

        if (!success)
        {
            return Ok("Add task failed");
        }

        return Ok("Add Task succeed");
    }

    [HttpDelete("delete-task/{employeeId}")]
    public async Task<IActionResult> DeleteTaskEmployee([FromRoute] int employeeId)
    {
        var (success, result) = await _taskService.DeleteTaskEmployee(employeeId);

        if (!success)
        {
            return Ok("Delete Employee Task failed");
        }
        
        return Ok("Delete Employee Task succeeded");
    }

    [HttpGet("get-all-task")]
    public List<Models.Task> GetAllTaskEmployee(GetEmployeeTaskRequest getEmployeeTaskRequest)
    {
        var result = _taskService.GetTaskEmployee(getEmployeeTaskRequest.Id, getEmployeeTaskRequest.StartDate,
            getEmployeeTaskRequest.EndDate);
        return result;
    }
}