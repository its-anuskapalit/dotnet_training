using StudentPortalMVC.Models;

namespace StudentPortalMVC.Repositories.Interfaces;

public interface IEnrollmentRepository : IGenericRepository<Enrollment>
{
    Task<bool> ExistsAsync(int studentId, int courseId);
}