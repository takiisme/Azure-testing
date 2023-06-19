using Models;

namespace WebApplication1.Services;

public interface IEmployeeService
{
    public Task<(bool success, object result)> AddEmployee(int id, string name, int gender, string role);
    public Task<(bool success, object result)> DeleteEmployee(int id);
    public Task<(bool success, object result)> ChangeEmployeeRole(int id, string role);
}

public class EmployeeService : IEmployeeService
{
    private readonly DbContext _dbContext;
    private readonly HelperService _helperService;

    public EmployeeService(DbContext dbContext, HelperService helperService)
    {
        _dbContext = dbContext;
        _helperService = helperService;
    }

    public async Task<(bool success, object result)> AddEmployee(int id, string name, int gender, string role)
    {
        var message = "Success";
        var EmployeeInformation = new Employee()
        {
            Id = id,
            Name = name,
            Gender = gender,
            Role = role
        };

        _dbContext.Employees.Add(EmployeeInformation);
        _dbContext.SaveChanges();

        return (true, message);
    }

    public async Task<(bool success, object result)> DeleteEmployee(int id)
    {
        var message = "Success";
        if (!_helperService.DoesEmployeeIdExist(id))
        {
            return (false, "Employee ID does not exist");
        }

        _dbContext.Remove(_dbContext.Employees.Single(x => x.Id == id));
        _dbContext.SaveChanges();
        return (true, message);
    }

    public async Task<(bool success, object result)> ChangeEmployeeRole(int id, string role)
    {
        if (!_helperService.DoesEmployeeIdExist(id))
        {
            return (false, "Employee ID does not exist");
        }

        var employee = _dbContext.Employees.First((x) => x.Id == id);
        employee.Role = role;
        _dbContext.SaveChanges();
        return (true, "Success");
    }
}