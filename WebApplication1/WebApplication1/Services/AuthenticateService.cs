using Microsoft.AspNetCore.Http.HttpResults;
using Models;

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
        var user = _dbContext.Accounts.SingleOrDefault(x => x.Username == username);

        if (user == null)
            return (false, "Account does not exist");

        if (user.Password != password)
            return (false, "Incorrect password");
                
        return (true, "Login successful");
    }

    public async Task<(bool success, object result)> Register(string username, string password)
    {
        if (_dbContext.Accounts.Any(x => x.Username == username))
            return (false, "Username is taken");

        var id = 1;
        if (_dbContext.Accounts.Any())
            id = _dbContext.Accounts.Max(x => x.Id);
                
        var newAccount = new Account()
        {
            Id = id,
            Username = username,
            Password = password,
        };

        _dbContext.Accounts.Add(newAccount);
        _dbContext.SaveChanges();
        return (true, "Register successful");
    }
}