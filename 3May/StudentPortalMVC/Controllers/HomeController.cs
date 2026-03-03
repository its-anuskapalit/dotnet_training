using Microsoft.AspNetCore.Mvc;
using StudentPortalMVC.Services.Interfaces;

namespace StudentPortalMVC.Controllers;

public class HomeController : Controller
{
    private readonly IDashboardService _dashboardService;

    public HomeController(IDashboardService dashboardService)
    {
        _dashboardService = dashboardService;
    }

    public async Task<IActionResult> Index()
    {
        var vm = await _dashboardService.GetDashboardDataAsync();
        return View(vm);
    }
}