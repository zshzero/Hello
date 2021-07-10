using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using YoloShop.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace YoloShop
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            if(args.Length == 1 && args[0].ToLower() == "seed")
            {
                RunSeeding(host);
                Console.WriteLine("Seeding Done");
            }
            else
                host.Run();
        }

        private static void RunSeeding(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var seeder = scope.ServiceProvider.GetService<YoloShopSeeder>();
                seeder.seedAsync().Wait();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration(AddConfiguration)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });

        private static void AddConfiguration(HostBuilderContext ctx, IConfigurationBuilder bldr)
        {
            bldr.Sources.Clear(); // Clearing other settings before we use our own
            bldr.SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("config.json") // Mentioning the config (web.config in .Net)
                .AddEnvironmentVariables(); // Setting env var
        }
    }
}
