using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScoreDbMVC.Data;
using ScoreDbMVC.Models;
namespace ScoreDbMVC.Controllers
{
    public class ScoreController : Controller
    {
        private readonly TrainingDBContext _context;

        public ScoreController(TrainingDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.Score.ToListAsync());
        }

        public async Task<IActionResult> Average()
        {
            var avgMarks = await _context.Score
                .AverageAsync(s => (double?)s.Marks) ?? 0;

            ViewBag.AverageMarks = avgMarks;
            return View();
        }
    }
}