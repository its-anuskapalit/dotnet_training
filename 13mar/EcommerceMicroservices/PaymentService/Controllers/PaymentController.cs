using Microsoft.AspNetCore.Mvc;

namespace PaymentService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PaymentController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetPayment()
        {
            return Ok("Payment Service Working");
        }

        [HttpPost]
        public IActionResult ProcessPayment()
        {
            var payment = new
            {
                PaymentId = 101,
                Status = "Success",
                Amount = 82000,
                Method = "Credit Card"
            };

            return Ok(payment);
        }
    }
}