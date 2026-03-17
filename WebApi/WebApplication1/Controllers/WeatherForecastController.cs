using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly AppDbContext _context;

        private static readonly string[] Summaries =
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild",
            "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public WeatherForecastController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet("random")]
        public IEnumerable<WeatherForecast> GetRandomWeather()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).ToArray();
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetWeatherFromDB()
        {
            return _context.WeatherForecasts.ToList();
        }

        [HttpPost]
        public IActionResult AddWeather(WeatherForecast weather)
        {
            _context.WeatherForecasts.Add(weather);
            _context.SaveChanges();

            return Ok(weather);
        }
    }
}