using System.Security.Claims;
using Models;

namespace WebApplication1.Services;

public interface IMcpService
{
    public Task<(bool success, object result)> AddMcp(int id, int capacity, int currentLoad);
    public List<Mcp> GetFullMcp();
}

public class McpService : IMcpService
{
    private readonly DbContext _dbContext;
    
    public McpService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public async Task<(bool success, object result)> AddMcp(int id, int capacity, int currentLoad)
    {
        var message = "Success";
        var McpInformation = new Mcp()
        {
            Id = id,
            Capacity = capacity,
            CurrentLoad = currentLoad,
            Latitude = "abc",
            Longitude = "def"
        };

        _dbContext.Mcps.Add(McpInformation);
        _dbContext.SaveChanges();

        return (true, message);
    }

    public List<Mcp> GetFullMcp()
    {
        var result = new List<Mcp>();
        var fullMcp = _dbContext.Mcps.Where(x => x.CurrentLoad >= 90).OrderBy(x => x.CurrentLoad);
        
        return fullMcp.ToList();
    }
}

// Linq (.First, ...)
// Github cua tao
// Code cai gi do di