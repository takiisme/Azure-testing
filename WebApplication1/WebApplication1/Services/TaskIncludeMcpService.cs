using Models;
using Task = System.Threading.Tasks.Task;

namespace WebApplication1.Services;

public interface ITaskIncludeMcpService
{
    public Task<(bool success, object result)> AddTaskIncludeMcp(int id, Models.Task task, int mcpId);
    public List<Models.Task> GetTaskContainsMcp(int mcpId);
}
public class TaskIncludeMcpService : ITaskIncludeMcpService
{
    private readonly DbContext _dbContext;
    private readonly HelperService _helperService;

    public TaskIncludeMcpService(DbContext dbContext, HelperService helperService)
    {
        _dbContext = dbContext;
        _helperService = helperService;
    }

    public async Task<(bool success, object result)> AddTaskIncludeMcp(int id, Models.Task task, int mcpId)
    {
        var message = "Success";

        if (!_helperService.DoesTaskIdExist(task.Id))
        {
            return (false, "Task id does not exist");
        }

        if (!_helperService.DoesMcpIdExist(mcpId))
        {
            return (false, "Mcp does not exist");
        }

        var taskIncludeMcpInformation = new TaskIncludeMcp()
        {
            Id = id,
            Task = task,
            McpId = mcpId,
        };

        _dbContext.TaskIncludeMcps.Add(taskIncludeMcpInformation);
        _dbContext.SaveChanges();
        
        return (true, message);
    }

    public List<Models.Task> GetTaskContainsMcp(int mcpId)
    {
        var result = new List<Models.Task>();
        var mcpInTask = _dbContext.TaskIncludeMcps.Where(x => x.McpId == mcpId);

        foreach (var item in mcpInTask)
        {
            var task = _dbContext.Tasks.Where(x => x.Id == item.Task.Id).ToList();
            result.AddRange(task);
        }
        
        return result;
    }
}