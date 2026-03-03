using Microsoft.AspNetCore.Mvc;
using StudentPortalMVC.Models;
using StudentPortalMVC.Services.Interfaces;

namespace StudentPortalMVC.Controllers;

public class CoursesController : Controller
{
    private readonly ICourseService _courseService;

    public CoursesController(ICourseService courseService)
    {
        _courseService = courseService;
    }

    // ================= LIST =================
    public async Task<IActionResult> Index()
    {
        var courses = await _courseService.GetAllCoursesAsync();
        return View(courses);
    }

    // ================= CREATE =================
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Course course)
    {
        if (!ModelState.IsValid) return View(course);

        await _courseService.CreateCourseAsync(course);
        return RedirectToAction(nameof(Index));
    }

    // ================= EDIT =================
    public async Task<IActionResult> Edit(int id)
    {
        var course = await _courseService.GetCourseByIdAsync(id);
        if (course == null) return NotFound();
        return View(course);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Course course)
    {
        if (!ModelState.IsValid) return View(course);

        var success = await _courseService.UpdateCourseAsync(course);
        if (!success) return NotFound();

        return RedirectToAction(nameof(Index));
    }
    

    // ================= DELETE =================
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _courseService.DeleteCourseAsync(id);

        if (!success)
            TempData["Error"] = "Cannot delete course with enrollments.";

        return RedirectToAction(nameof(Index));
    }

    // ================= AJAX STATUS =================
    [HttpPost]
    public async Task<IActionResult> ToggleStatus(int id, bool isActive)
    {
        var result = await _courseService.UpdateStatusAsync(id, isActive);
        return Json(new { success = result });
    }
}