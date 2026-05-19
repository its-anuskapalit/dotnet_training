using StudentPortalMVC.Models;

namespace StudentPortalMVC.Services.Interfaces;

public interface ICourseService
{
    Task<IEnumerable<Course>> GetAllCoursesAsync();
    Task<Course?> GetCourseByIdAsync(int id);
    Task<bool> CreateCourseAsync(Course course);
    Task<bool> UpdateCourseAsync(Course course);
    Task<bool> DeleteCourseAsync(int id);
    Task<bool> UpdateStatusAsync(int courseId, bool isActive);
}