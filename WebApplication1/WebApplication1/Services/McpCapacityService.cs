using Cronos;

namespace WebApplication1.Services;

public interface IMcpCapacityService
{
    public float GetCapacity(int mcpId);
}

public class McpCapacityService : IMcpCapacityService
{
    public float GetCapacity(int mcpId)
    {
        return 0.5f;
    }
}

public class MockCapacityService : IMcpCapacityService
{
    private readonly DbContext _dbContext;
    private readonly HelperService _helperService;

    MockCapacityService(DbContext dbContext, HelperService helperService)
    {
        _dbContext = dbContext;
        _helperService = helperService;
    }

    public float GetCapacity(int mcpId)
    {
        if (!_helperService.DoesMcpIdExist(mcpId))
        {
            return -1.0f;
        }
        
        Random rnd = new Random();
        int num = rnd.Next(minValue:1, maxValue:20);

        var mcpUpdated = _dbContext.Mcps.First(x => x.Id == mcpId);
        mcpUpdated.Capacity += num;
        _dbContext.SaveChanges();
        return mcpUpdated.Capacity;
    }
}

public class McpCapacityServiceUpdater : BackgroundService
{
    private const float MCP_CAPACITY_UPDATE_TIMER = 10f;

    private readonly IServiceScopeFactory _serviceScopeFactory;
    private readonly HelperService _helperService;

    public McpCapacityServiceUpdater(IServiceScopeFactory serviceScopeFactory, HelperService helperService)
    {
        _serviceScopeFactory = serviceScopeFactory;
        _helperService = helperService;
    }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        
    }
}