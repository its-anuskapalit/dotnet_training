using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiCRUD.Models;
namespace WebApiCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly StudentDBContext _context;
        public StudentApiController(StudentDBContext context)
        {
            this._context = context;
        }
        //Read
        [HttpGet]
        public async Task<ActionResult<List<Student>>> GetStudents()
        {
            var data = await _context.Students.ToListAsync();
            return Ok(data);
        }
        [HttpGet("index/{id}")]
        public async Task<ActionResult<List<Student>>> GetStudentById(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        //Create
        [HttpPost]
        public async Task<ActionResult<List<Student>>> CreateStudent(Student std)
        {
            await _context.Students.AddAsync(std);
            await _context.SaveChangesAsync();
            return Ok(std);
        }
        //Update
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Student>>> UpdateStudent(int id, Student std)
        {
            if (id != std.Id)
            {
                return BadRequest();
            }
            _context.Entry(std).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(std);

        }
        //Delete
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Student>>> DeleteStudent(int id)
        {
            var std = await _context.Students.FindAsync(id);
            if (std == null)
            {
                return NotFound();
            }
            _context.Students.Remove(std);
            await _context.SaveChangesAsync();
            return Ok();

        }


    }
}
