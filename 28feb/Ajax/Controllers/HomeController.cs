using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Ajax.Models;

namespace Ajax.Controllers;

using Microsoft.AspNetCore.Mvc;


    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult GetGreeting(string name)
        {
            string message = "Hello, " + name + "!";
            return Json(message);
        }
    }

