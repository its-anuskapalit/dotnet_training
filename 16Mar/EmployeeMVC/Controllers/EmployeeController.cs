using Microsoft.AspNetCore.Mvc;
using EmployeeMVC.Data;
using EmployeeMVC.Models;
using System.Linq;
namespace EmployeeMVC.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDbContext db;
        public EmployeeController(AppDbContext context)
        {
            db = context;
        }
        public IActionResult Index()
        {
            var employees = db.Employees.ToList();
            return View(employees);
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Employee emp)
        {
            db.Employees.Add(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int id)
        {
            var emp = db.Employees.Find(id);
            return View(emp);
        }
        [HttpPost]
        public IActionResult Edit(Employee emp)
        {
            db.Employees.Update(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Details(int id)
        {
            var emp = db.Employees.Find(id);
            return View(emp);
        }
        public IActionResult Delete(int id)
        {
            var emp = db.Employees.Find(id);
            return View(emp);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var emp = db.Employees.Find(id);
            db.Employees.Remove(emp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}