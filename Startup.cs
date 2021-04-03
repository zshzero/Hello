using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Hello.Services;

namespace Hello
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<ILogService, LogService>();

            services.AddControllersWithViews(); // Required Services for the app
            services.AddRazorPages() // Includes razor pages
                .AddRazorRuntimeCompilation();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if(env.IsDevelopment()) { // Checks for value of ASPNETCORE_ENVIRONMENT in launch.json
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/error"); // Friendly error page
            }
            
            app.UseStaticFiles(); // It serves only files present in wwwroot(which is like root of the web server)

            app.UseRouting(); // Allows us to route individual calls that come into server
            
            app.UseEndpoints( cfg => 
            { // Specifies set of middleware that tries to satisfy request from server
                cfg.MapRazorPages();
                
                cfg.MapControllerRoute("Default",
                "/{controller}/{action}/{id?}",     // Pattern to much for controllers and view(action)
                new { controller = "App", action="Index"});
            });
        }
    }
}
