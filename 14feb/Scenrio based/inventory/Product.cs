using System;

namespace Inventory
{
    public abstract class Product
    {
        public string Id { get; set; }
        public decimal Price { get; set; }

        protected Product(string id, decimal price)
        {
            Id = id;
            Price = price;
        }

        public abstract void DisplayDetails();
    }
}
