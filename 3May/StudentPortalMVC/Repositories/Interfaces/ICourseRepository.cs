using StudentPortalMVC.Models;

namespace StudentPortalMVC.Repositories.Interfaces;

public interface ICourseRepository : IGenericRepository<Course>
{
    Task<bool> HasEnrollmentsAsync(int courseId);
}