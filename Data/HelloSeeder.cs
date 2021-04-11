using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Hello.Data.Entities;
using Microsoft.AspNetCore.Hosting;

namespace Hello.Data
{
    public class HelloSeeder
    {
        private readonly HelloContext ctx;
        private readonly IWebHostEnvironment env;

        public HelloSeeder(HelloContext ctx, IWebHostEnvironment env)
        {
            this.ctx = ctx;
            this.env = env;
        }

        public void seed()
        {
            ctx.Database.EnsureCreated(); // creates only if it doesn't exists

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