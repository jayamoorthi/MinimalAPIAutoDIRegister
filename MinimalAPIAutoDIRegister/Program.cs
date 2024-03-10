using Domain.Interfaces;
using Domain.Services;
using Infrastructure.InventoryDb;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
string assemblyName = typeof(InventoryDbContext).Namespace;
var connectionString = configuration.GetConnectionString("TestDb");
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddDbContext<InventoryDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly(assemblyName)));

// Add services to the container.
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Auto EndPoint Register
builder.Services.AddEndPoints(typeof(Program).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Auto EndPoint Register
app.MapEndpoints();  

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