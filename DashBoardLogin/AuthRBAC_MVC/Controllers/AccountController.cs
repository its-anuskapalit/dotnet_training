using Microsoft.AspNetCore.Mvc;
using AuthRBAC_MVC.Models;
using AuthRBAC_MVC.Models.ViewModels;
using Microsoft.EntityFrameworkCore;

public class AccountController : Controller
{
    private readonly AuthRBAC_DBContext _context;

    public AccountController(AuthRBAC_DBContext context)
    {
        _context = context;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginViewModel model)
    {
        var user = _context.Users
            .FirstOrDefault(x => x.Username == model.Username);

        if (user == null)
        {
            ViewBag.Error = "Invalid Username";
            return View();
        }

        if (user.PasswordHash != model.Password)
        {
            ViewBag.Error = "Invalid Password";
            return View();
        }

        HttpContext.Session.SetInt32("UserId", user.UserId);
        HttpContext.Session.SetString("Username", user.Username);

        return RedirectToAction("Index", "Dashboard");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Login");
    }
}