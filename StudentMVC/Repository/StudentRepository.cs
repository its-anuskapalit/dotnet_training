using Microsoft.EntityFrameworkCore;
using StudentPortalMvc.Models;

namespace StudentPortalMvc.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentPortalDbContext _context;

        public StudentRepository(StudentPortalDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllAsync()
        {
            return await _context.Students
                .OrderByDescending(x => x.StudentId)
                .ToListAsync();
        }
        public async Task<Student?> GetByIdAsync(int id)
        {
            return await _context.Students.FindAsync(id);
        }

        public async Task AddAsync(Student student)
        {
            await _context.Students.AddAsync(student);
        }

        public async Task UpdateAsync(Student student)
        {
            _context.Students.Update(student);
        }

        public async Task DeleteAsync(int id)
        {
            var student = await _context.Students.FindAsync(id);
            if (student != null)
                _context.Students.Remove(student);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Students.AnyAsync(x => x.Email == email);
        }
    }
}