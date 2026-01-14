using System;

namespace OrderProcessingSystem.Models
{
    /// <summary>
    /// Stores history of every status change.
    /// </summary>
    public class OrderStatusLog
    {
        public OrderStatus OldStatus { get; set; }
        public OrderStatus NewStatus { get; set; }
        public DateTime ChangedOn { get; set; }
    }
}
