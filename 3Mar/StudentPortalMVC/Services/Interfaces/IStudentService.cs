// // using StudentPortalMVC.Models;
// // using StudentPortalMVC.ViewModels;
// // using StudentPortalMVC.DTOs;
// // namespace StudentPortalMVC.Services.Interfaces;

// // public interface IStudentService
// // {
    
// //     Task<bool> CreateStudentAsync(StudentCreateDto dto);
// //     Task<IEnumerable<Student>> GetAllStudentsAsync();
// //     Task<Student?> GetStudentByIdAsync(int id);
// //     Task<bool> CreateStudentAsync(Student student);
// //     Task<bool> UpdateStudentAsync(Student student);
// //     Task<bool> DeleteStudentAsync(int id);
// //     Task<bool> EmailExistsAsync(string email);
// //     Task<Student?> GetStudentWithEnrollmentsAsync(int id);
// //     Task<DashboardVM> GetDashboardDataAsync();
// //     Task<bool> UpdateStatusAsync(int studentId, bool isActive);
    
// // }
using StudentPortalMVC.DTOs;
using StudentPortalMVC.ViewModels;

namespace StudentPortalMVC.Services.Interfaces;

public interface IStudentService
{
    Task<IEnumerable<StudentListDto>> GetAllStudentsAsync();

    Task<StudentUpdateDto?> GetStudentByIdAsync(int id);

    Task<bool> CreateStudentAsync(StudentCreateDto dto);

    Task<bool> UpdateStudentAsync(StudentUpdateDto dto);

    Task<bool> DeleteStudentAsync(int id);

    Task<bool> EmailExistsAsync(string email);

    Task<DashboardVM> GetDashboardDataAsync();

    Task<bool> UpdateStatusAsync(int studentId, bool isActive);
}