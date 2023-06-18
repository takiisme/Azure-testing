namespace WebApplication1.Services;

public class HelperService
{
    private readonly IServiceScopeFactory _serviceScopeFactory;
        
    public HelperService(IServiceScopeFactory serviceScopeFactory)
    {
        _serviceScopeFactory = serviceScopeFactory;
    }

    public bool DoesIdEmployeeExist(int employeeID)
    {
        using var scope = _serviceScopeFactory.CreateScope();
        var dbContext = scope.ServiceProvider.GetRequiredService<DbContext>();
        return dbContext.Employees.Any((x) => x.Id == employeeID);
    }
}