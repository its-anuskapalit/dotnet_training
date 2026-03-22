using Microsoft.AspNetCore.Mvc;

public class AccountController : Controller
{
    private JwtService _jwtService = new JwtService();

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(string username, string password)
    {
        // Fake users (replace with DB later)
        if (username == "admin" && password == "123")
        {
            var token = _jwtService.GenerateToken(username, "Admin");
            Response.Cookies.Append("jwt", token);
            return RedirectToAction("AdminDashboard", "Home");
        }

        if (username == "student" && password == "123")
        {
            var token = _jwtService.GenerateToken(username, "Student");
            Response.Cookies.Append("jwt", token);
            return RedirectToAction("StudentDashboard", "Home");
        }

        ViewBag.Error = "Invalid login";
        return View();
    }

    public IActionResult Logout()
    {
        Response.Cookies.Delete("jwt");
        return RedirectToAction("Login");
    }
}