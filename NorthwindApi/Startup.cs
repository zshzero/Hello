using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using NorthwindApi.Services;
using NorthwindApi.Extensions;
using NorthwindApi.Models;
using Npgsql;
using System.Net.Http.Headers;

namespace NorthwindApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "NorthwindApi", Version = "v1" });
            });
            services.AddDbContext<NorthwindContext>();
            services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(System.Environment.GetEnvironmentVariable("Northwind_ContextDB")));
            // https://stackoverflow.com/questions/9218847/how-do-i-handle-database-connections-with-dapper-in-net/47403685#47403685
            services.AddStackExchangeRedisCache(options => {
                options.Configuration = System.Environment.GetEnvironmentVariable("Northwind_RedisDB");
                options.InstanceName = "NorthwindApi_";
            });
            // https://stackoverflow.com/questions/56272957/what-are-the-key-difference-in-using-redis-cache-via-connectionmultiplexer
            services.AddScoped<IRepository,Repository>();
            services.AddTransient<INorthwindWebService, NorthwindWebService>();
            services.AddHttpClient("NorthwindWebService", client => {
                client.BaseAddress = new Uri(Configuration.GetValue<String>("NorthwindWebServiceURI"));
                client.DefaultRequestHeaders
                        .Accept
                        .Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // https://stackoverflow.com/questions/10679214/how-do-you-set-the-content-type-header-for-an-httpclient-request
            });
            // https://docs.microsoft.com/en-us/aspnet/core/fundamentals/http-requests
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILogger<ErrorResponse> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "NorthwindApi v1"));
            }

            app.ConfigureExceptionHandler(logger);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    //https://docs.microsoft.com/en-us/aspnet/core/mvc/controllers/routing?view=aspnetcore-5.0#conventional-routing
                    name: "Default",
                    pattern: "/{controller=App}/{action=Index}/{id?}"
                );
            });
        }
    }
}
