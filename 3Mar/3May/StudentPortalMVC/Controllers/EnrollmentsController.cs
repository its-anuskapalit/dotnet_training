using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StudentPortalMVC.Models;
using StudentPortalMVC.Services.Interfaces;

namespace StudentPortalMVC.Controllers;

public class EnrollmentsController : Controller
{
    private readonly IEnrollmentService _service;
    private readonly IStudentService _studentService;
    private readonly ICourseService _courseService;

    public EnrollmentsController(
        IEnrollmentService service,
        IStudentService studentService,
        ICourseService courseService)
    {
        _service = service;
        _studentService = studentService;
        _courseService = courseService;
    }

    // ===== INDEX =====
    public async Task<IActionResult> Index()
    {
        var data = await _service.GetAllAsync();
        return View(data);
    }

    // ===== CREATE GET =====
    public async Task<IActionResult> Create()
    {
        await LoadDropdowns();   // ✅ MUST CALL
        return View(new Enrollment());
    }

    // ===== CREATE POST =====
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Enrollment enrollment)
    {
        if (!ModelState.IsValid)
        {
            await LoadDropdowns();  // ✅ MUST CALL AGAIN
            Console.WriteLine("Students loaded: " + (ViewBag.Students != null));
    Console.WriteLine("Courses loaded: " + (ViewBag.Courses != null));
            return View(enrollment);
        }

        var success = await _service.CreateAsync(enrollment);

        if (!success)
        {
            ModelState.AddModelError("", "Student already enrolled in this course.");
            await LoadDropdowns();  // ✅ MUST CALL AGAIN
            return View(enrollment);
        }

        return RedirectToAction(nameof(Index));
    }

    // ===== DELETE =====
    public async Task<IActionResult> Delete(int id)
    {
        await _service.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    // =========================================
    // ✅ ADD LoadDropdowns HERE (BOTTOM)
    // =========================================
    private async Task LoadDropdowns()
    {
        var students = await _studentService.GetAllStudentsAsync();
        var courses = await _courseService.GetAllCoursesAsync();

        if (students == null)
            students = new List<Student>();

        if (courses == null)
            courses = new List<Course>();

        var studentList = students.ToList();
        var courseList = courses.ToList();

        ViewBag.Students = new SelectList(studentList, "StudentId", "FullName");
        ViewBag.Courses = new SelectList(courseList, "CourseId", "Title");
    }
}