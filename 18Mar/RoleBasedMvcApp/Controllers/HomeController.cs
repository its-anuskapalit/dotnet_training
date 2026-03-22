using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    [Authorize(Roles = "Admin")]
    public IActionResult AdminDashboard()
    {
        return View();
    }

    [Authorize(Roles = "Student")]
    public IActionResult StudentDashboard()
    {
        return View();
    }

    [Authorize]
    public IActionResult Common()
    {
        return View();
    }
}