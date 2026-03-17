using Microsoft.AspNetCore.Mvc;
namespace OrderService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetOrders()
        {
            var orders = new[]
            {
                new { OrderId = 1001, Product = "Laptop", Amount = 80000 },
                new { OrderId = 1002, Product = "Headphones", Amount = 2000 }
            };

            return Ok(orders);
        }
    }
}