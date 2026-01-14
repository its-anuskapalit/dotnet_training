using System;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Services
{
    /// <summary>
    /// Sends notification messages to logistics team.
    /// </summary>
    public class LogisticsNotificationService
    {
        public void Notify(Order order, OrderStatus oldStatus, OrderStatus newStatus)
        {
            Console.WriteLine($"[Logistics] Order {order.Id} is now {newStatus}");
        }
    }
}
