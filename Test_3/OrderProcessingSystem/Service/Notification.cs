using System;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Services
{
    /// <summary>
    /// Sends notification messages to customers.
    /// </summary>
    public class CustomerNotificationService
    {
        public void Notify(Order order, OrderStatus oldStatus, OrderStatus newStatus)
        {
            Console.WriteLine($"[Customer] Your order {order.Id} changed from {oldStatus} to {newStatus}");
        }
    }
}
