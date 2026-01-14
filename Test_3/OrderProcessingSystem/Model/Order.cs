using System.Collections.Generic;

namespace OrderProcessingSystem.Models
{
    /// <summary>
    /// Represents a complete order with multiple products and status history.
    /// </summary>
    public class Order
    {
        public int Id { get; private set; }
        public Customer Customer { get; private set; }
        public List<OrderItem> Items { get; private set; } = new List<OrderItem>();
        public OrderStatus CurrentStatus { get; set; } = OrderStatus.Created;
        public List<OrderStatusLog> History { get; private set; } = new List<OrderStatusLog>();

        public Order(int id, Customer customer)
        {
            Id = id;
            Customer = customer;
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
                total += item.GetTotal();
            return total;
        }
    }
}
