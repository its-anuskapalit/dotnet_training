namespace OrderProcessingSystem.Models
{
    /// <summary>
    /// Represents all possible stages of an order lifecycle.
    /// </summary>
    public enum OrderStatus
    {
        Created,
        Paid,
        Packed,
        Shipped,
        Delivered,
        Cancelled
    }
}
