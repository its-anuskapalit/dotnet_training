using StudentPortalMVC.Models;

namespace StudentPortalMVC.Repositories.Interfaces;

public interface IStudentRepository : IGenericRepository<Student>
{
    Task<bool> EmailExistsAsync(string email);
    Task<Student?> GetStudentWithEnrollmentsAsync(int studentId);
}