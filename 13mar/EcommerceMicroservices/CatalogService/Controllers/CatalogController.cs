using Microsoft.AspNetCore.Mvc;
namespace CatalogService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CatalogController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = new[]
            {
                new { Id = 1, Name = "Laptop", Price = 80000 },
                new { Id = 2, Name = "Mobile", Price = 30000 },
                new { Id = 3, Name = "Headphones", Price = 2000 }
            };
            return Ok(products);
        }
    }
}