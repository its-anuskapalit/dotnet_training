using Microsoft.EntityFrameworkCore;
using StudentPortalMVC.Data;
using StudentPortalMVC.Models;
using StudentPortalMVC.Repositories.Interfaces;

namespace StudentPortalMVC.Repositories.Implementations;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    private readonly StudentPortalDbContext _context;

    public StudentRepository(StudentPortalDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _context.Students.AnyAsync(s => s.Email == email);
    }

    public async Task<Student?> GetStudentWithEnrollmentsAsync(int studentId)
    {
        return await _context.Students
            .Include(s => s.Enrollments)
            .ThenInclude(e => e.Course)
            .FirstOrDefaultAsync(s => s.StudentId == studentId);
    }
}