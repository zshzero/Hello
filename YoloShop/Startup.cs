using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using YoloShop.Services;
using YoloShop.Data;
using System.Reflection;
using YoloShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace YoloShop
{
    public class Startup
    {
        private readonly IConfiguration configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<StoreUser, IdentityRole>(cfg =>
            {
                cfg.User.RequireUniqueEmail = true;                
            })
                    .AddEntityFrameworkStores<YoloShopContext>();
            services.AddAuthentication()
                    .AddCookie()
                    .AddJwtBearer( cfg => 
                    {
                        cfg.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidIssuer = configuration["Token:Issuer"],
                            ValidAudience = configuration["Token:Audience"],
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Token:Key"]))
                        };
                    });
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddTransient<YoloShopSeeder>();
            services.AddDbContext<YoloShopContext>();
            services.AddTransient<ILogService, LogService>();
            services.AddScoped<IYoloShopRepository,YoloShopRepository>();

            services.AddControllersWithViews(); // Required Services for the app
            services.AddRazorPages() // Includes razor pages
                    .AddRazorRuntimeCompilation()
                    .AddNewtonsoftJson( cfg => cfg.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
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

            app.UseAuthentication();
            app.UseAuthorization();
            
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
