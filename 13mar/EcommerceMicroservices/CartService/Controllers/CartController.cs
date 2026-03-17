using Microsoft.AspNetCore.Mvc;
namespace CartService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CartController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetCart()
        {
            var cart = new
            {
                UserId = 1,
                Items = new[]
                {
                    new { ProductId = 1, Name = "Laptop", Quantity = 1 },
                    new { ProductId = 3, Name = "Headphones", Quantity = 2 }
                }
            };
            return Ok(cart);
        }
    }
}