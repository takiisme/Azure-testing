using Microsoft.AspNetCore.Http.HttpResults;

namespace WebApplication1.Services;

public interface IAuthenticateService
{
    public Task<(bool success, object result)> Login(string username, string password);
    public Task<(bool success, object result)> Register(string username, string password);
}

public class AuthenticateService : IAuthenticateService
{
    private readonly DbContext _dbContext;

    public AuthenticateService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<(bool success, object result)> Login(string username, string password)
    {
        return (true, "Login successful");
    }

    public async Task<(bool success, object result)> Register(string username, string password)
    {
        return (true, "Register successful");
    }
}