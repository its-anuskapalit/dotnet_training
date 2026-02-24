using Microsoft.AspNetCore.Mvc;
using TodoMvcApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace TodoMvcApp.Controllers
{
    public class TodoController : Controller
    {
        private static List<TodoItem> todos = new List<TodoItem>();
        private static int nextId = 1;

        public IActionResult Index()
        {
            return View(todos);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(TodoItem item)
        {
            item.Id = nextId++;
            todos.Add(item);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var item = todos.FirstOrDefault(x => x.Id == id);
            return View(item);
        }

        [HttpPost]
        public IActionResult Edit(TodoItem updated)
        {
            var item = todos.FirstOrDefault(x => x.Id == updated.Id);
            if (item != null)
            {
                item.Title = updated.Title;
                item.IsDone = updated.IsDone;
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var item = todos.FirstOrDefault(x => x.Id == id);
            if (item != null) todos.Remove(item);
            return RedirectToAction("Index");
        }
        public IActionResult Toggle(int id)
        {
            var item = todos.FirstOrDefault(x => x.Id == id);
            if (item != null)
                item.IsDone = !item.IsDone;

            return RedirectToAction("Index");
        }
    }
}