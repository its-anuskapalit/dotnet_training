namespace OrderProcessingSystem.Models
{
    /// <summary>
    /// Represents a customer who places orders.
    /// </summary>
    public class Customer
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
