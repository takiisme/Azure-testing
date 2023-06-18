using Microsoft.EntityFrameworkCore;
using Models;

namespace WebApplication1;

public class DbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbContext(DbContextOptions<DbContext> options) : base(options) {}
    public DbSet<Mcp> Mcps { get; set; }
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Account> Accounts { get; set; }
}