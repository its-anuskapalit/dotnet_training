using Microsoft.AspNetCore.Mvc;
using studentapi.Models;
namespace studentapi.Controllers;

[ApiController]
[Route("api/students")]
public class StudentsController : ControllerBase
{
    private static List<Student> students = new List<Student>()
    {
        new Student { Id = 1, Name = "Anuska" },
        new Student { Id = 2, Name = "Polly" },
        new Student { Id = 3, Name = "Sachin" },

    };

    [HttpGet]
    public IActionResult GetStudents()
    {
        return Ok(students);
    }

    [HttpGet("{id}")]
    public IActionResult GetStudent(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
            return NotFound();

        return Ok(student);
    }

    [HttpPost]
    public IActionResult AddStudent(Student student)
    {
        students.Add(student);
        return Created("", student);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateStudent(int id, Student updatedStudent)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
            return NotFound();

        student.Name = updatedStudent.Name;

        return Ok(student);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteStudent(int id)
    {
        var student = students.FirstOrDefault(s => s.Id == id);

        if (student == null)
            return NotFound();

        students.Remove(student);

        return Ok("Student deleted");
    }
}