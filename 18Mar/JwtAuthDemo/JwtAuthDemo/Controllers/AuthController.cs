using JwtAuthDemo.Models;
using JwtAuthDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthDemo.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    // In-memory user store (replace with DB later)
    private static readonly List<User> _users = new();
    private static int _nextId = 1;

    private readonly JwtService _jwtService;

    public AuthController(JwtService jwtService)
    {
        _jwtService = jwtService;
    }

    // POST api/auth/register
    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        // Check if username already exists
        if (_users.Any(u => u.Username == request.Username))
            return BadRequest("Username already exists.");

        // Hash the password — NEVER store plain text!
        var user = new User
        {
            Id = _nextId++,
            Username = request.Username,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(request.Password),
            Role = request.Role
        };

        _users.Add(user);
        return Ok(new { message = "User registered successfully!", userId = user.Id });
    }

    // POST api/auth/login
    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        // Find the user
        var user = _users.FirstOrDefault(u => u.Username == request.Username);

        // Verify password against hash
        if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
            return Unauthorized("Invalid username or password.");

        // Generate and return JWT
        var token = _jwtService.GenerateToken(user);
        return Ok(new { token, expiresIn = "60 minutes" });
    }
}