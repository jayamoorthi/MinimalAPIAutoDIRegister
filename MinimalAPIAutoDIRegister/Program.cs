using Domain.Interfaces;
using Domain.Services;
using Domain.Validators;
using Infrastructure;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using MinimalAPIAutoDIRegister.Extensions;
using Serilog;

Log.Logger  = new LoggerConfiguration().WriteTo.Console().CreateBootstrapLogger();

Log.Information("starting up"); 

try
{ 
    var builder = WebApplication.CreateBuilder(args);

    //builder.Host.UseSerilog((ctx, lc) => lc
    //.WriteTo.Console());

    builder.Host.UseSerilog((ctx, lc) => lc
         .WriteTo.Console()
         .WriteTo.Seq("http://localhost:5341")
         .ReadFrom.Configuration(ctx.Configuration));



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

// Apply db migration if any pending migrations when app start
app.ApplyDbMigration(configuration);

// Serialog middleware
app.UseSerilogRequestLogging();

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

app.MapGet("/", () => "Hello World!");

 app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Unhandled exception");
}
finally
{
    Log.Information("Shut down complete");
    Log.CloseAndFlush();
}


 // Net 5 

//internal void Configure(IApplicationBuilder app, IWebHostEnvironment env)
//{

//    // migrate any database changes on startup (includes initial db creation)
//    using (var scope = app.ApplicationServices.CreateScope())
//    {
//        var db = scope.ServiceProvider.GetRequiredService<InventoryDbContext>();
//        db.Database.Migrate();
//    }

//}