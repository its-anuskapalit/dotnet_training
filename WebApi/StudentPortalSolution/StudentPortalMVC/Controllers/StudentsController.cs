// using Microsoft.AspNetCore.Mvc;
// using StudentPortalMVC.Models;
// using System.Text.Json;

// namespace StudentPortalMVC.Controllers
// {
//     public class StudentsController : Controller
//     {
//         private readonly HttpClient _client;

//         public StudentsController()
//         {
//             _client = new HttpClient();
//             _client.BaseAddress = new Uri("http://localhost:5137/");
//         }

//         public async Task<IActionResult> Index()
//         {
//             var response = await _client.GetAsync("api/Students");

//             if (!response.IsSuccessStatusCode)
//             {
//                 return View(new List<Student>());
//             }

//             var data = await response.Content.ReadAsStringAsync();

//             var students = JsonSerializer.Deserialize<List<Student>>(data,
//                 new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

//             return View(students);
//         }
//     }
// }
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Json;
using StudentPortalMVC.Models;

namespace StudentPortalMVC.Controllers
{
    public class StudentsController : Controller
    {
        private readonly HttpClient _client = new HttpClient
        {
            BaseAddress = new Uri("http://localhost:5137/")
        };

        public async Task<IActionResult> Index()
        {
            var students = await _client.GetFromJsonAsync<List<Student>>("api/Students");
            return View(students);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Student student)
        {
            await _client.PostAsJsonAsync("api/Students", student);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            var student = await _client.GetFromJsonAsync<Student>($"api/Students/{id}");
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student student)
        {
            await _client.PutAsJsonAsync($"api/Students/{student.StudentId}", student);
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Delete(int id)
        {
            await _client.DeleteAsync($"api/Students/{id}");
            return RedirectToAction("Index");
        }
    }
}