namespace OrderProcessingSystem.Models
{
    /// <summary>
    /// Represents a product that can be purchased by customers.
    /// </summary>
    public class Product
    {
        public int Id { get; private set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public Product(int id, string name, decimal price)
        {
            Id = id;
            Name = name;
            Price = price;
        }
    }
}
