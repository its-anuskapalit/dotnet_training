using Microsoft.EntityFrameworkCore;
using StudentPortalMVC.Data;
using StudentPortalMVC.Models;
using StudentPortalMVC.Repositories.Interfaces;

namespace StudentPortalMVC.Repositories.Implementations;

public class CourseRepository : GenericRepository<Course>, ICourseRepository
{
    private readonly StudentPortalDbContext _context;

    public CourseRepository(StudentPortalDbContext context) : base(context)
    {
        _context = context;
    }

    public async Task<bool> HasEnrollmentsAsync(int courseId)
    {
        return await _context.Enrollments
            .AnyAsync(e => e.CourseId == courseId);
    }
}