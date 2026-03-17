using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using CRUDAppMVC.Models;
using System.Text;

namespace CRUDAppMVC.Controllers
{
    public class StudentController : Controller
    {
        private string url = "http://localhost:5146/api/Studentapi";
        private HttpClient client = new HttpClient();

        [HttpGet]
        public IActionResult Index()
        {
            List<Student> students = new List<Student>();
            HttpResponseMessage response = client.GetAsync(url).Result;
            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                var data = JsonConvert.DeserializeObject<List<Student>>(result);

                if (data != null)
                {
                    students = data;
                }
            }
            return View(students);
        }
        // show form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        // submit form
        [HttpPost]
        public IActionResult Create(Student std)
        {
            var data = JsonConvert.SerializeObject(std);
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PostAsync(url, content).Result;
            if (response.IsSuccessStatusCode)
            {
                TempData["insert_message"] = "Student Added..";
                return RedirectToAction("Index");
            }
            return View(std);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            Student std = new Student();

            HttpResponseMessage response = client.GetAsync(url + "/index/" + id).Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;

                std = JsonConvert.DeserializeObject<Student>(result);
            }

            return View(std);
        }

        [HttpPost]
        public IActionResult Edit(Student std)
        {
            var data = JsonConvert.SerializeObject(std);

            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

            HttpResponseMessage response = client.PutAsync($"{url}/{std.Id}", content).Result;

            if (response.IsSuccessStatusCode)
            {
                TempData["update_message"] = "Student Updated..";
                return RedirectToAction("Index");
            }

            return View(std);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            Student std = new Student();

            HttpResponseMessage response = client.GetAsync($"{url}/index/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                std = JsonConvert.DeserializeObject<Student>(result);
            }

            return View(std);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            Student std = new Student();

            HttpResponseMessage response = client.GetAsync($"{url}/{id}").Result;

            if (response.IsSuccessStatusCode)
            {
                string result = response.Content.ReadAsStringAsync().Result;
                std = JsonConvert.DeserializeObject<Student>(result);
            }

            return View(std);
        }
        [HttpPost, ActionName("Delete")]
public IActionResult DeleteConfirmed(int id)
{
    HttpResponseMessage response = client.DeleteAsync($"{url}/{id}").Result;

    if (response.IsSuccessStatusCode)
    {
        TempData["delete_message"] = "Student Deleted..";
        return RedirectToAction("Index");
    }

    return View();
}

    }
}