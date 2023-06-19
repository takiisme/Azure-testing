namespace WebApplication1.Services;

public class HelperService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;

    public HelperService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public bool DoesEmployeeIdExist(int employeeId)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
        return dbContext.Employees.Any((x) => x.Id == employeeId);
    }

    public bool DoesMcpIdExist(int mcpId)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
        return dbContext.Mcps.Any((x) => x.Id == mcpId);
    }
    
    public bool DoesMessageIdExist(int messageId)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
        return dbContext.Messages.Any((x) => x.Id == messageId);
    }
    
    public bool DoesTaskIdExist(int taskId)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
        return dbContext.Tasks.Any((x) => x.Id == taskId);
    }
}