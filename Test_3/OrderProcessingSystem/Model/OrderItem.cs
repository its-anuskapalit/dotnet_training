namespace OrderProcessingSystem.Models
{
    /// <summary>
    /// Represents one product entry inside an order.
    /// Demonstrates composition: Order HAS OrderItems.
    /// </summary>
    public class OrderItem
    {
        public Product Product { get; private set; }
        public int Quantity { get; private set; }
        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }
        public decimal GetTotal()
        {
            return Product.Price * Quantity;
        }
    }
}
