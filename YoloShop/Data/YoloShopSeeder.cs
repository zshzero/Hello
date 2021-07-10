using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using YoloShop.Data.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;

namespace YoloShop.Data
{
    public class YoloShopSeeder
    {
        private readonly YoloShopContext ctx;
        private readonly IWebHostEnvironment env;
        private readonly UserManager<StoreUser> userManager;

        public YoloShopSeeder(YoloShopContext ctx, IWebHostEnvironment env, UserManager<StoreUser> userManager)
        {
            this.ctx = ctx;
            this.env = env;
            this.userManager = userManager;
        }

        public async Task seedAsync()
        {
            ctx.Database.EnsureCreated(); // creates only if it doesn't exists

            StoreUser user = await userManager.FindByEmailAsync("zshzero@hello.com");

            if(user == null)
            {
                user = new StoreUser()
                {
                    Email = "zshzero@hello.com",
                    UserName = "zshzero"
                };

                var result = await userManager.CreateAsync(user,"P@ssw0rd!");

                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Couldn't create new user in seeder");
                }
            }

            if (!ctx.Products.Any()) // There aren't any product
            {
                // Need to create Sample Data
                var FilePath = Path.Combine(env.ContentRootPath,"Data/art.json");
                var json = File.ReadAllText(FilePath);
                var products = JsonSerializer.Deserialize<IEnumerable<Product>>(json);
                ctx.Products.AddRange(products);
                
                 var order = new Order()
                 {
                     OrderDate = DateTime.Today,
                     OrderNumber = "1000",
                     Items = new List<OrderItem>()
                     {
                         new OrderItem()
                         {
                             Product = products.First(),
                             Quantity = 3,
                             UnitPrice = products.First().Price
                         }
                     }
                 };
                ctx.Orders.Add(order);
                
                ctx.SaveChanges();
            }
        }
    }
}