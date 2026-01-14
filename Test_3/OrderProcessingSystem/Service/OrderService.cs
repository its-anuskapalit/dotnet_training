using System;
using OrderProcessingSystem.Models;

namespace OrderProcessingSystem.Services
{
    /// <summary>
    /// Delegate that fires whenever order status is changed.
    /// </summary>
    public delegate void OrderStatusChangedHandler(Order order, OrderStatus oldStatus, OrderStatus newStatus);

    /// <summary>
    /// Contains all order workflow logic and validations.
    /// </summary>
    public class OrderService
    {
        public OrderStatusChangedHandler OnStatusChanged;

        public void ChangeStatus(Order order, OrderStatus newStatus)
        {
            if (order.CurrentStatus == OrderStatus.Cancelled)
                throw new Exception("Cancelled order cannot be updated.");

            if (newStatus == OrderStatus.Packed && order.CurrentStatus != OrderStatus.Paid)
                throw new Exception("Order must be Paid before Packing.");

            if (newStatus == OrderStatus.Shipped && order.CurrentStatus != OrderStatus.Packed)
                throw new Exception("Order must be Packed before Shipping.");

            if (newStatus == OrderStatus.Delivered && order.CurrentStatus != OrderStatus.Shipped)
                throw new Exception("Order must be Shipped before Delivery.");

            OrderStatus old = order.CurrentStatus;
            order.CurrentStatus = newStatus;

            order.History.Add(new OrderStatusLog
            {
                OldStatus = old,
                NewStatus = newStatus,
                ChangedOn = DateTime.Now
            });

            OnStatusChanged?.Invoke(order, old, newStatus);
        }
    }
}
