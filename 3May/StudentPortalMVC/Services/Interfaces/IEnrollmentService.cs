using StudentPortalMVC.Models;

namespace StudentPortalMVC.Services.Interfaces;

public interface IEnrollmentService
{
    Task<IEnumerable<Enrollment>> GetAllAsync();
    Task<Enrollment?> GetByIdAsync(int id);
    Task<bool> CreateAsync(Enrollment enrollment);
    Task<bool> DeleteAsync(int id);
    
}