using Microsoft.AspNetCore.Mvc;
using StudentPortalMVC.Models;
using StudentPortalMVC.Services.Interfaces;

namespace StudentPortalMVC.Controllers;

public class StudentsController : Controller
{
    private readonly IStudentService _studentService;

    public StudentsController(IStudentService studentService)
    {
        _studentService = studentService;
    }
    [HttpPost]
public async Task<IActionResult> ToggleStatus(int id, bool isActive)
{
    var result = await _studentService.UpdateStatusAsync(id, isActive);

    if (!result)
        return Json(new { success = false, message = "Student not found" });

    return Json(new { success = true });
}

    // ===================== LIST =====================
    public async Task<IActionResult> Index()
    {
        var students = await _studentService.GetAllStudentsAsync();
        return View(students);
    }

    // ===================== DETAILS =====================
    public async Task<IActionResult> Details(int id)
    {
        var student = await _studentService.GetStudentWithEnrollmentsAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    // ===================== CREATE GET =====================
    public IActionResult Create()
    {
        return View();
    }

    // ===================== CREATE POST =====================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Student student)
    {
        if (!ModelState.IsValid)
            return View(student);

        var success = await _studentService.CreateStudentAsync(student);

        if (!success)
        {
            ModelState.AddModelError("Email", "Email already exists.");
            return View(student);
        }

        return RedirectToAction(nameof(Index));
    }

    // ===================== EDIT GET =====================
    public async Task<IActionResult> Edit(int id)
    {
        var student = await _studentService.GetStudentByIdAsync(id);
        if (student == null) return NotFound();
        return View(student);
    }

    // ===================== EDIT POST =====================
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Student student)
    {
        if (!ModelState.IsValid)
            return View(student);

        var success = await _studentService.UpdateStudentAsync(student);
        if (!success) return NotFound();

        return RedirectToAction(nameof(Index));
    }

    // ===================== DELETE =====================
    public async Task<IActionResult> Delete(int id)
    {
        var success = await _studentService.DeleteStudentAsync(id);

        if (!success)
            TempData["Error"] = "Cannot delete student with enrollments.";

        return RedirectToAction(nameof(Index));
    }
}