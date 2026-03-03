using StudentPortalMVC.Models;
using StudentPortalMVC.Repositories.Interfaces;
using StudentPortalMVC.Services.Interfaces;

namespace StudentPortalMVC.Services.Implementations;

// Handles enrollment business logic
public class EnrollmentService : IEnrollmentService
{
    private readonly IEnrollmentRepository _repo;

    // Constructor injection
    public EnrollmentService(IEnrollmentRepository repo)
    {
        _repo = repo;
    }

    // Get all enrollments
    public async Task<IEnumerable<Enrollment>> GetAllAsync()
    {
        return await _repo.GetAllAsync();
    }

    // Get by id
    public async Task<Enrollment?> GetByIdAsync(int id)
    {
        return await _repo.GetByIdAsync(id);
    }

    // Create enrollment with duplicate check
    public async Task<bool> CreateAsync(Enrollment enrollment)
    {
        var exists = await _repo.ExistsAsync(enrollment.StudentId, enrollment.CourseId);
        if (exists) return false;

        enrollment.CreatedAt = DateTime.Now;
        enrollment.EnrollDate = DateOnly.FromDateTime(DateTime.Now);

        await _repo.InsertAsync(enrollment);
        await _repo.SaveAsync();
        return true;
    }

    // Delete enrollment
    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _repo.GetByIdAsync(id);
        if (entity == null) return false;

        _repo.Delete(entity);
        await _repo.SaveAsync();
        return true;
    }
}