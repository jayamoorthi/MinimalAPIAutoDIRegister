using Domain.Interfaces;
using Domain.Services;
using Domain.Validators;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using MinimalAPIAutoDIRegister.Extensions;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
string assemblyName = typeof(InventoryDbContext).Namespace;
var connectionString = configuration.GetConnectionString("TestDb");
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddDbContext<InventoryDbContext>(options => options.UseSqlServer(connectionString, b => b.MigrationsAssembly(assemblyName)));

// DI register FluentValidation 
builder.Services.AddFluentValidation();



// Add DI services to the container.
builder.Services.AddMediatR(cf => cf.RegisterServicesFromAssembly(typeof(Program).Assembly));

// Automaitcally EndPoint register 
builder.Services.AddEndPoints(typeof(Program).Assembly);

// Automapper register
builder.Services.AddAutoMapper(typeof(Program).Assembly);

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