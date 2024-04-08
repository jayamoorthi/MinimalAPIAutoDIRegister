using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MinimalAPIAutoDIRegister.Extensions
{
    public static class DbMigrationExtension
    {
        public static void ApplyDbMigration(this WebApplicationBuilder app, IConfiguration configuration)
        {
           var dbContext = new InventoryDbContext(new DbContextOptionsBuilder<InventoryDbContext>()
                .UseSqlServer(configuration.GetConnectionString("TestDb"))
                .Options);
            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                Console.WriteLine($"You have {pendingMigrations.Count()} pending migrations to apply.");
                Console.WriteLine("Applying pending migrations now");
                dbContext.Database.Migrate();             
            }
        }

        public static void GetPendingDbMigrationList(IConfiguration configuration)
        {
            using var dbContext = new InventoryDbContext(new DbContextOptionsBuilder<InventoryDbContext>()
                 .UseSqlServer(configuration.GetConnectionString("TestDb"))
                 .Options);

            var modelDiffer = dbContext.GetService<IMigrationsModelDiffer>();
            var migrationsAssembly = dbContext.GetService<IMigrationsAssembly>();

            //var pendingModelChanges = modelDiffer
            //    .GetDifferences(
            //        migrationsAssembly.ModelSnapshot?.Model,
            //        dbContext.Model);


            //if (dbContext.Database.GetPendingMigrations().Any())
            //    dbContext.Database.Migrate();

        }
    }
}
