using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MiddlewareCheck.Models;

namespace MiddlewareCheck.Controllers;
public class TestController : Controller
{
    public IActionResult Echo(string q, string ans)
    {
        return Content($"You sent {q} = {ans}");
    }
}