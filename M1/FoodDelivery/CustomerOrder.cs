using System;
namespace FoodDelivery{
public enum OrderStatus
{
    Created,
    PaymentPending,
    PaymentProcessing,
    PaymentFailed,
    PaymentSuccessful,
    RestaurantAccepted,
    RestaurantPreparing,
    RestaurantReady,
    DriverAssigned,
    DriverPickedUp,
    OutForDelivery,
    Delivered,
    Cancelled,
    Refunded
}

public class CustomerOrder
{
    public string OrderId { get; set; }
    public Customer Customer { get; set; }
    public Restaurant Restaurant { get; set; }
    public List<OrderItem> Items { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal DeliveryFee { get; set; }
    public string DeliveryAddress { get; set; }
    public OrderStatus Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? EstimatedDeliveryTime { get; set; }
    public Driver AssignedDriver { get; set; }
    public string PaymentTransactionId { get; set; }
    public string FailureReason { get; set; }
}
}