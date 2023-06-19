using Models;

namespace WebApplication1.Services;

public interface ITaskService
{
    public Task<(bool success, object result)> AddTask(int id, DateTime date, int employeeId);
    public Task<(bool success, object result)> DeleteTaskEmployee(int id);
    public List<Models.Task> GetTaskEmployee(int id, DateTime start, DateTime end);
}

public class TaskService : ITaskService
{
    private readonly DbContext _dbContext;
    private readonly HelperService _helperService;

    public TaskService(DbContext dbContext, HelperService helperService)
    {
        _dbContext = dbContext;
        _helperService = helperService;
    }

    public async Task<(bool success, object result)> AddTask(int id, DateTime date, int employeeId)
    {
        var message = "Success";

        if (!_helperService.DoesEmployeeIdExist(employeeId))
        {
            return (false, "Employee with Id does not exist");
        }

        var worker = _dbContext.Employees.First(x => x.Id == employeeId);
        
        var taskInformation = new Models.Task()
        {
            Id = id,
            Date = date,
            Worker = worker,
        };

        _dbContext.Tasks.Add(taskInformation);
        _dbContext.SaveChanges();
        return (true, message);
    }

    public async Task<(bool success, object result)> DeleteTaskEmployee(int id)
    {
        var message = "Success";
        
        if (!_helperService.DoesEmployeeIdExist(id))
        {
            return (false, "Employee with Id does not exist");
        }

        var taskList = _dbContext.Tasks.Where(x => x.Worker.Id == id);
        _dbContext.Tasks.RemoveRange(taskList);
        _dbContext.SaveChanges();
        return (true, message);
    }

    public List<Models.Task> GetTaskEmployee(int id, DateTime start, DateTime end)
    {
        var result = new List<Models.Task>();

        if (!_helperService.DoesEmployeeIdExist(id))
        {
            return result;
        }

        var getTaskEmployee = _dbContext.Tasks.Where(x => x.Date >= start && x.Date <= end && x.Worker.Id == id);
        return getTaskEmployee.ToList();
    }
}