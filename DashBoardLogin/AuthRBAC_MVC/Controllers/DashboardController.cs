using Microsoft.AspNetCore.Mvc;
using AuthRBAC_MVC.Models;
using Microsoft.EntityFrameworkCore;

public class DashboardController : Controller
{
    private readonly AuthRBAC_DBContext _context;

    public DashboardController(AuthRBAC_DBContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var userId = HttpContext.Session.GetInt32("UserId");

        if (userId == null)
            return RedirectToAction("Login", "Account");

        var modules = _context.UserRoles
            .Where(u => u.UserId == userId)
            .Join(_context.RoleModules,
                ur => ur.RoleId,
                rm => rm.RoleId,
                (ur, rm) => rm)
            .Join(_context.Modules,
                rm => rm.ModuleId,
                m => m.ModuleId,
                (rm, m) => m)
            .ToList();

        return View(modules);
    }
}