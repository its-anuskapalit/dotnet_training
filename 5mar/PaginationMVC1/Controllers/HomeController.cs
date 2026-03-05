using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PaginationMVC1.Models;    

namespace PaginationMVC1.Controllers;

public class HomeController : Controller
{
    private readonly AdventureWorksContext _context;

    public HomeController(AdventureWorksContext context)
    {
        _context = context;
    }

    public IActionResult Index(int page = 1, string search = "")
    {
        int pageSize = 15;

        var query = _context.People.AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(p => p.FirstName.Contains(search) 
                                  || p.LastName.Contains(search));
        }

        var people = query
            .OrderBy(p => p.BusinessEntityId)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        ViewBag.Page = page;
        ViewBag.Search = search;

        return View(people);
    }
    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
