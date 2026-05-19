using Microsoft.EntityFrameworkCore;
using StudentPortalMVC.Data;
using StudentPortalMVC.Models;
using StudentPortalMVC.Repositories.Interfaces;

namespace StudentPortalMVC.Repositories.Implementations;

public class EnrollmentRepository : GenericRepository<Enrollment>, IEnrollmentRepository
{
    private readonly StudentPortalDbContext _context;

    public EnrollmentRepository(StudentPortalDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> ExistsAsync(int studentId, int courseId)
    {
        return await _context.Enrollments
            .AnyAsync(e => e.StudentId == studentId && e.CourseId == courseId);
    }
}