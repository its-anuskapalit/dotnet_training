using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentPortalMvc.Models;

namespace StudentPortalMvc.Controllers
{
    public class EnrollmentsController : Controller
    {
        private readonly StudentPortalDbContext _context;

        public EnrollmentsController(StudentPortalDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var data = _context.Enrollments
                .Include(e => e.Student)
                .Include(e => e.Course);

            return View(await data.ToListAsync());
        }

        public IActionResult Create()
        {
            ViewBag.StudentId = new SelectList(_context.Students, "StudentId", "FullName");
            ViewBag.CourseId = new SelectList(_context.Courses, "CourseId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Enrollment enrollment)
        {
            if (ModelState.IsValid)
            {
                enrollment.CreatedAt = DateTime.Now;
                _context.Add(enrollment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.StudentId = new SelectList(_context.Students, "StudentId", "FullName", enrollment.StudentId);
            ViewBag.CourseId = new SelectList(_context.Courses, "CourseId", "Title", enrollment.CourseId);
            return View(enrollment);
        }
    }
}