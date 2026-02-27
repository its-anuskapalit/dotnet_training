using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DbFirstDemo.Data;
using DbFirstDemo.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace DbFirstDemo.Controllers
{
    public class ProjectController : Controller
    {
        private readonly TrainingDBContext _context;

        public ProjectController(TrainingDBContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var projects = await _context.Project
                .Include(p => p.Employee)
                .ToListAsync();

            return View(projects);
        }

        public IActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(_context.Employees, "EmployeeId", "FullName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Project project)
        {
            if (ModelState.IsValid)
            {
                _context.Add(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.EmployeeId = new SelectList(_context.Employees, "EmployeeId", "FullName", project.EmployeeId);
            return View(project);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var project = await _context.Project.FindAsync(id);
            if (project == null) return NotFound();

            ViewBag.EmployeeId = new SelectList(_context.Employees, "EmployeeId", "FullName", project.EmployeeId);
            return View(project);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Project project)
        {
            if (id != project.Id) return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(project);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.EmployeeId = new SelectList(_context.Employees, "EmployeeId", "FullName", project.EmployeeId);
            return View(project);
        }
        public async Task<IActionResult> Delete(int id)
        {
            var project = await _context.Project.FindAsync(id);
            if (project == null) return NotFound();
            return View(project);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var project = await _context.Project.FindAsync(id);
            if (project != null)
            {
                _context.Project.Remove(project);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var project = await _context.Project.FirstOrDefaultAsync(x => x.Id == id);
            if (project == null) return NotFound();
            return View(project);
        }
    }
}