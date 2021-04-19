using System.Collections.Generic;
using Hello.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hello.Data
{
    public interface IHelloRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string Category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int id);
        void AddEntity(object model);
    }
}