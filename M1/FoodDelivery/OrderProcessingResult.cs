using System;
namespace FoodDelivery
{
  public class OrderProcessingResult
{
    public bool IsSuccess { get; set; }
    public string OrderId { get; set; }
    public DateTime? EstimatedDeliveryTime { get; set; }
    public string ErrorMessage { get; set; }
}
  
}