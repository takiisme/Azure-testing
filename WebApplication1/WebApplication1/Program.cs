using Microsoft.EntityFrameworkCore;
using WebApplication1.Services;
using DbContext = WebApplication1.DbContext;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbContext>(o => o.UseSqlServer(builder.Configuration.GetConnectionString("Db")));
builder.Services.AddScoped<IMcpService, McpService>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();
builder.Services.AddScoped<IAuthenticateService, AuthenticateService>();
builder.Services.AddScoped<IMessageService, MessageService>();
builder.Services.AddScoped<ITaskService, TaskService>();

builder.Services.AddSingleton<McpCapacityServiceUpdater>();
builder.Services.AddHostedService<McpCapacityServiceUpdater>(p => p.GetRequiredService<McpCapacityServiceUpdater>());
builder.Services.AddSingleton<HelperService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();