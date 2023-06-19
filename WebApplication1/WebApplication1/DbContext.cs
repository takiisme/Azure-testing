using Microsoft.EntityFrameworkCore;
using Models;
using WebApplication1.Services;

namespace WebApplication1;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options) : base(options) {}
    public DbSet<Mcp> Mcps { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Account> Accounts { get; set; }
    public DbSet<Message> Messages { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    
    public DbSet<TaskIncludeMcp> TaskIncludeMcps { get; set; }
}