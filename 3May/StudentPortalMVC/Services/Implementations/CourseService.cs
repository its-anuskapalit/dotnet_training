using StudentPortalMVC.Models;
using StudentPortalMVC.Repositories.Interfaces;
using StudentPortalMVC.Services.Interfaces;

namespace StudentPortalMVC.Services.Implementations;

public class CourseService : ICourseService
{
    private readonly ICourseRepository _courseRepository;

    public CourseService(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<IEnumerable<Course>> GetAllCoursesAsync()
{
    var data = await _courseRepository.GetAllAsync();
    return data ?? Enumerable.Empty<Course>();
}

    public async Task<Course?> GetCourseByIdAsync(int id)
    {
        return await _courseRepository.GetByIdAsync(id);
    }

    public async Task<bool> CreateCourseAsync(Course course)
    {
        course.CreatedAt = DateTime.Now;

        await _courseRepository.InsertAsync(course);
        await _courseRepository.SaveAsync();
        return true;
    }

    public async Task<bool> UpdateCourseAsync(Course course)
{
    var existing = await _courseRepository.GetByIdAsync(course.CourseId);
    if (existing == null) return false;

    existing.Title = course.Title;
    existing.DurationDays = course.DurationDays;
    existing.Fee = course.Fee;
    existing.Level = course.Level;
    existing.IsActive = course.IsActive;

    _courseRepository.Update(existing); // ✅ REQUIRED NOW
    await _courseRepository.SaveAsync();

    return true;
}

    public async Task<bool> DeleteCourseAsync(int id)
    {
        var course = await _courseRepository.GetByIdAsync(id);
        if (course == null) return false;

        var hasEnrollments = await _courseRepository.HasEnrollmentsAsync(id);
        if (hasEnrollments) return false;

        _courseRepository.Delete(course);
        await _courseRepository.SaveAsync();
        return true;
    }

    public async Task<bool> UpdateStatusAsync(int courseId, bool isActive)
    {
        var course = await _courseRepository.GetByIdAsync(courseId);
        if (course == null) return false;

        course.IsActive = isActive;

        _courseRepository.Update(course);
        await _courseRepository.SaveAsync();
        return true;
    }
}