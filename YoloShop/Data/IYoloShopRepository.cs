using System.Collections.Generic;
using YoloShop.Data.Entities;
using Microsoft.AspNetCore.Mvc;

namespace YoloShop.Data
{
    public interface IYoloShopRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string Category);
        bool SaveAll();
        IEnumerable<Order> GetAllOrders(bool includeItems);
        Order GetOrderById(int id);
        void AddEntity(object model);
        IEnumerable<Order> GetAllOrdersByUser(string username, bool includeItems);
    }
}