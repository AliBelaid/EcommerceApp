using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.identity;
using Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Identity;
using Infrastructure.Identity;
namespace API {
    public class Program {
        public static async Task Main (string[] args) {
            var host = CreateHostBuilder (args).Build ();
            using (var scope = host.Services.CreateScope ()) {
                var services = scope.ServiceProvider;
                var loggerFactory = services.GetRequiredService<ILoggerFactory> ();
                try {
                    var context = services.GetRequiredService<StoreContext> ();
                    await context.Database.MigrateAsync();
                      
                await StoreContextSeed.SeedAsync(context ,loggerFactory);
                
                var userManger = services.GetRequiredService<UserManager<AppUser>>();
                var identityContext = services.GetRequiredService<AppIdentityDbContext>();
                await identityContext.Database.MigrateAsync();
                await AppIdentityDbContextSeed.SeedUsersAsync(userManger);
                } catch (Exception err) {
                    var logger = loggerFactory.CreateLogger<Program> ();
                    logger.LogError (err, "An error occurred during migration");
                }
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder (string[] args) =>
            Host.CreateDefaultBuilder (args)
            .ConfigureWebHostDefaults (webBuilder => {
                webBuilder.UseStartup<Startup> ();
            });
    }
}