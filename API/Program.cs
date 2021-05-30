using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using KPI.SportStuffInternetShop.Data;
using Microsoft.AspNetCore.Identity;
using KPI.SportStuffInternetShop.Domains.Identity;

namespace KPI.SportStuffInternetShop.API {

    public class Program
    {
        public static async Task<int> Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try {
                    var dbContext = services.GetRequiredService<ApplicationDbContext>();
                    await dbContext.Database.MigrateAsync();
                    var userManager = services.GetRequiredService<UserManager<User>>();
                    await SeedData.SeedAsync(dbContext, userManager, loggerFactory);
                } catch (Exception ex) {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogError(ex, "An error occurred during migration");
                    return 1;
                }
            }

            using (var scope = host.Services.CreateScope()) {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory>();
                try {
                    await host.RunAsync();
                    return 0;
                } catch (Exception ex) {
                    var logger = loggerFactory.CreateLogger<Program>();
                    logger.LogCritical(ex, "An error occurred during running the application");
                    return 1;
                }
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
