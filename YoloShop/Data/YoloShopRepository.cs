using System.Collections.Generic;
using System.Linq;
using YoloShop.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace YoloShop.Data
{

    public class YoloShopRepository : IYoloShopRepository
    {
        private readonly YoloShopContext ctx;
        private readonly ILogger logger;

        public YoloShopRepository(YoloShopContext ctx, ILogger<YoloShopRepository> logger)
        {
            this.ctx = ctx;
            this.logger = logger;
        }

        public void AddEntity(object model)
        {
            ctx.Add(model);
        }

        public IEnumerable<Order> GetAllOrders(bool includeItems)
        {
            if (includeItems)
            {
                return ctx.Orders.Include( o => o.Items)
                                .ThenInclude( i => i.Product)
                                .ToList();                
            }
            else 
            {
                return ctx.Orders.ToList();
            }
        }

        public IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems)
        {
             if (includeItems)
            {
                return ctx.Orders.Where(o => o.User.UserName == username)
                                .Include( o => o.Items)
                                .ThenInclude( i => i.Product)
                                .ToList();                
            }
            else 
            {
                return ctx.Orders.ToList();
            }
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