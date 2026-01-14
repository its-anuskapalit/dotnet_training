using System.Collections.Generic;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Data
{
    /// <summary>
    /// Stores all products in memory using Dictionary for fast lookup by Id.
    /// </summary>
    public class ProductRepository
    {
        private Dictionary<int, Product> _products = new Dictionary<int, Product>();

        public ProductRepository()
        {
            _products.Add(1, new Product(1, "Laptop", 50000));
            _products.Add(2, new Product(2, "Headphones", 2000));
            _products.Add(3, new Product(3, "Mouse", 500));
            _products.Add(4, new Product(4, "Keyboard", 800));
            _products.Add(5, new Product(5, "Monitor", 12000));
        }

        public Dictionary<int, Product> GetAll()
        {
            return _products;
        }

        public Product GetById(int id)
        {
            return _products.ContainsKey(id) ? _products[id] : null;
        }
    }
}
