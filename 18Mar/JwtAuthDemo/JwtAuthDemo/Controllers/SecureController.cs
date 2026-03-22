using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class SecureController : ControllerBase
{
    // Any logged-in user can access this
    [HttpGet("profile")]
    [Authorize]
    public IActionResult GetProfile()
    {
        // Read claims from the validated JWT
        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var username = User.FindFirst(ClaimTypes.Name)?.Value;
        var role = User.FindFirst(ClaimTypes.Role)?.Value;

        return Ok(new
        {
            message = "You accessed a protected route!",
            userId,
            username,
            role
        });
    }

    // ONLY Admin role can access this
    [HttpGet("admin")]
    [Authorize(Roles = "Admin")]
    public IActionResult AdminOnly()
    {
        return Ok(new { message = "Welcome, Admin! You have elevated access." });
    }

    // Public — no token needed
    [HttpGet("public")]
    public IActionResult PublicEndpoint()
    {
        return Ok(new { message = "Anyone can see this — no token needed!" });
    }
}