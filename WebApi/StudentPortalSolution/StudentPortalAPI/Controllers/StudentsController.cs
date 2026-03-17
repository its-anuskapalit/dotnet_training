using Microsoft.AspNetCore.Mvc;
using StudentPortal.Data.Models;
using StudentPortalAPI.Interfaces;

namespace StudentPortalAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentRepository _repository;

        public StudentsController(IStudentRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _repository.GetAllStudents();
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _repository.GetStudentById(id);

            if (student == null)
                return NotFound();

            return Ok(student);
        }

        [HttpPost]
        public async Task<IActionResult> AddStudent(Student student)
        {
            var result = await _repository.AddStudent(student);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            var deleted = await _repository.DeleteStudent(id);

            if (!deleted)
                return NotFound();

            return Ok();
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStudent(int id, Student student)
        {
            if (id != student.StudentId)
                return BadRequest();

            var result = await _repository.UpdateStudent(student);

            return Ok(result);
        }
    }
}