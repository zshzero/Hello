using System.Collections.Generic;
using System.Linq;
using Hello.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Hello.Data
{

    public class HelloRepository : IHelloRepository
    {
        private readonly HelloContext ctx;
        private readonly ILogger logger;

        public HelloRepository(HelloContext ctx, ILogger<HelloRepository> logger)
        {
            this.ctx = ctx;
            this.logger = logger;
        }

        public void AddEntity(object model)
        {
            ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return ctx.Orders.Include( o => o.Items)
                             .ThenInclude( i => i.Product)
                             .ToList();
        }

        public IEnumerable<Product> GetAllProducts()
        {
            try
            {
               return ctx.Products
                    .OrderBy(p => p.Title)
                    .ToList(); 
            }
            catch (System.Exception ex)
            {   
                logger.LogError($"Failed : {ex}");
                return null;
            }
            
        }

        public Order GetOrderById(int id)
        {
            return ctx.Orders.Include( o => o.Items)
                             .ThenInclude( i => i.Product)
                             .Where( w => w.Id.Equals(id))
                             .FirstOrDefault();
        }

        public IEnumerable<Product> GetProductsByCategory(string Category)
        {
            return ctx.Products
                    .Where(p => p.Category == Category)
                    .ToList();
        }

        public bool SaveAll()
        {
            return ctx.SaveChanges() > 0;
        }
    }
}