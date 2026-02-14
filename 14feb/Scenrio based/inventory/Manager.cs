using System;
using System.Collections.Generic;

namespace Inventory
{
    public class InventoryManager
    {
        private List<Product> products = new List<Product>();

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void DisplayAllProducts()
        {
            foreach (var product in products)
            {
                product.DisplayDetails();
            }
        }
    }
}
