using Microsoft.AspNetCore.Mvc;
using RecommendationAPI.Data;
using RecommendationAPI.Models;

namespace RecommendationAPI.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RatingController : ControllerBase
{
    private readonly ApplicationDbContext _context;

    public RatingController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public IActionResult AddRating(Rating rating)
    {
        _context.Ratings.Add(rating);
        _context.SaveChanges();
        return Ok(rating);
    }

    [HttpGet]
    public IActionResult GetRatings()
    {
        return Ok(_context.Ratings.ToList());
    }
}