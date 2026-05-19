using StudentPortalMVC.Models;
using StudentPortalMVC.ViewModels;

namespace StudentPortalMVC.Services.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<Student>> GetAllStudentsAsync();
    Task<Student?> GetStudentByIdAsync(int id);
    Task<bool> CreateStudentAsync(Student student);
    Task<bool> UpdateStudentAsync(Student student);
    Task<bool> DeleteStudentAsync(int id);
    Task<bool> EmailExistsAsync(string email);
    Task<Student?> GetStudentWithEnrollmentsAsync(int id);
    Task<DashboardVM> GetDashboardDataAsync();
    Task<bool> UpdateStatusAsync(int studentId, bool isActive);
}