// using System.Diagnostics;
// using Microsoft.AspNetCore.Mvc;
// using listPractice.Models;

// namespace listPractice.Controllers;

// public class HomeController : Controller
// {

//     // public IActionResult Index()
//     // {
//     //     ViewBag.Variable = "India, China, Korea, Thailand, Sri Lanka";
//     //     ViewBag.countries = ViewBag.Variable.ToString().Split(',');
//     //     return View();
//     // }
//     public ActionResult Index()
//     {
//         ViewData["Message"] = "Hello from the Controller!";
//         ViewData["CurrentDate"] = DateTime.Now;

//         // You can also pass complex objects like a list of employees
//         var employees = new List<Employee>
//     {
//         new Employee { EmployeeId = 1, EmployeeName = "John Doe" },
//         new Employee { EmployeeId = 2, EmployeeName = "Jane Smith" }
//     };
//         ViewData["Employees"] = employees;

//         return View();
//     }


//     public IActionResult Privacy()
//     {
//         return View();
//     }

//     [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//     public IActionResult Error()
//     {
//         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//     }
// }



using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace listPractice.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["Message"] = "Hello from the Controller!";
            ViewData["CurrentDate"] = DateTime.Now;

            var employees = new List<Employee>
            {
                new Employee { EmployeeId = 1, EmployeeName = "Anuska" },
                new Employee { EmployeeId = 2, EmployeeName = "Polly" }
            };

            ViewData["Employees"] = employees;

            return View();
        }
    }
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string EmployeeName { get; set; }
    }
}