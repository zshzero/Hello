using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using NorthwindApi.Models;
using Serilog;

namespace NorthwindApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
            // https://nblumhardt.com/2020/10/bootstrap-logger
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureAppConfiguration((hostingContext, config) =>
                {
                    // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/?tabs=basicconfiguration&view=aspnetcore-5.0#environment-variables
                    config.AddEnvironmentVariables(prefix: "Northwind_")
                          .AddJsonFile($"appsettings.{hostingContext.HostingEnvironment.EnvironmentName}.json")
                          .Build();
                })
                .UseSerilog((hostingcontext, services, config) => config
                    .ReadFrom.Configuration(hostingcontext.Configuration)
                    .ReadFrom.Services(services)
                    .Enrich.FromLogContext()
                    .Enrich.With<RemoveSerilogProperties>()
                    // https://github.com/serilog/serilog-aspnetcore#two-stage-initialization
                )
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
