using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Diagnostics;

namespace MinimalAPIAutoDIRegister.Extensions
{
    public static class DbMigrationExtension
    {
        public static void ApplyDbMigration(this WebApplication application, IConfiguration configuration)
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

        public static async void GetPendingDbMigrationList(this WebApplication application,IConfiguration configuration)
        {
            using var dbContext = new InventoryDbContext(new DbContextOptionsBuilder<InventoryDbContext>()
                 .UseSqlServer(configuration.GetConnectionString("TestDb"))
                 .Options);

            var modelDiffer = dbContext.GetService<IMigrationsModelDiffer>();
            var migrationsAssembly = dbContext.GetService<IMigrationsAssembly>();

            
            var pendingMigrations = dbContext.Database.GetPendingMigrations();
            if (pendingMigrations.Any())
            {
                var FirstMigration = pendingMigrations.FirstOrDefault();
                var LastMigration = pendingMigrations.Last();

                string filename = "powershell.exe";
                string args = "";
                if(FirstMigration != LastMigration)
                {
                     args = $" Script-Migration -From {FirstMigration} - To {LastMigration} -Output sqlscript/{FirstMigration}-{LastMigration}-Migration.Sql";
                }
                else
                {
                    args = $" Script-Migration {FirstMigration} --Output sqlscript/{FirstMigration}-Migration.Sql";
                }
                args = "dotnet ef migrations script 20240407045143_Add-Rolemaster --project MinimalAPIAutoDIRegister --output migrationscript/script.sql";
                var e = DotnetNativeWrapper.GetVersion(filename, args);
                Console.WriteLine($"{e}");


            }
            //var pendingModelChanges = modelDiffer
            //    .GetDifferences(
            //        migrationsAssembly!.ModelSnapshot?.Model,
            //        dbContext.Model);


            //if (dbContext.Database.GetPendingMigrations().Any())
            //    dbContext.Database.Migrate();

        }
    }


    public static class DotnetNativeWrapper
    {
        public static async Task<Version> GetVersion(string filename, string args)
        {
            ProcessStartInfo startInfo1 = new()
            {
                FileName = "dotnet",
                Arguments = "--version",
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            ProcessStartInfo startInfo = new()
            {
                FileName = filename,
                Arguments = args,
                CreateNoWindow = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
            };

            var processStartInfo = new ProcessStartInfo();
            processStartInfo.WorkingDirectory = @"C:\Users\91978\CleanArch\NewTemplate\MinimalAPIAutoDIRegister\";
            processStartInfo.FileName = "powershell.exe";
            processStartInfo.Arguments = $"-Command \"{args}\"";
            processStartInfo.UseShellExecute = false;
            processStartInfo.RedirectStandardOutput = true;
          


            using var process = new Process();
            process.StartInfo = processStartInfo;
            process.Start();
            process.WaitForExit();
            string output = process.StandardOutput.ReadToEnd();
           // Console.Writeline(output);
            //var proc = Process.Start(startInfo);

            //ArgumentNullException.ThrowIfNull(proc);

            //string output = proc.StandardOutput.ReadToEnd();
            //await proc.WaitForExitAsync();

            return Version.Parse(output);
        }
    }
}
