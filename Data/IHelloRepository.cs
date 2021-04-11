using System.Collections.Generic;
using Hello.Data.Entities;

namespace Hello.Data
{
    public interface IHelloRepository
    {
        IEnumerable<Product> GetAllProducts();
        IEnumerable<Product> GetProductsByCategory(string Category);
        bool SaveAll();
    }
}