using System.Security.Claims;
using Models;

namespace WebApplication1.Services;

public interface IMcpService
{
    public Task<(bool success, object result)> AddMcp(int id);
}

public class McpService : IMcpService
{
    private readonly DbContext _dbContext;
    
    public McpService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<(bool success, object result)> AddMcp(int id)
    {
        var message = "Success";
        var McpInformation = new Mcp()
        {
            Id = id,
            Capacity = 100,
            CurrentLoad = 50,
            Latitude = "abc",
            Longitude = "def"
        };

        _dbContext.Mcps.Add(McpInformation);
        _dbContext.SaveChanges();

        return (true, message);
    }
}

// Linq (.First, ...)
// Github cua tao
// Code cai gi do di