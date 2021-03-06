using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace NorthwindApi.Models
{
    public class NorthwindContext : DbContext
    {
        private readonly IConfiguration configuration;

        public NorthwindContext(DbContextOptions<NorthwindContext> options, IConfiguration configuration)
            : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Employee> employees { get; set; }
        public DbSet<Order> orders { get; set; }

         protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(System.Environment.GetEnvironmentVariable("Northwind_ContextDB"));
        }
    }
}