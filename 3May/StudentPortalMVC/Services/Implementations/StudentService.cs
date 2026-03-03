using StudentPortalMVC.Models;
using StudentPortalMVC.Repositories.Interfaces;
using StudentPortalMVC.Services.Interfaces;
using StudentPortalMVC.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace StudentPortalMVC.Services.Implementations;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }
    public async Task<bool> UpdateStatusAsync(int studentId, bool isActive)
{
    var student = await _studentRepository.GetByIdAsync(studentId);
    if (student == null) return false;

    student.Status = isActive ? "Active" : "Inactive";

    _studentRepository.Update(student);
    await _studentRepository.SaveAsync();

    return true;
}
public async Task<DashboardVM> GetDashboardDataAsync()
{
    var students = await _studentRepository.GetAllAsync();

    var studentsWithEnrollments = await _studentRepository
        .GetAllAsync(include: q => q.Include(s => s.Enrollments));

    // Better approach using context (clean but simple for now)

    var dashboard = new DashboardVM();

    dashboard.TotalStudents = students.Count();
    dashboard.ActiveCourses = 0; // will improve later
    dashboard.TotalEnrollments = studentsWithEnrollments.SelectMany(s => s.Enrollments).Count();
    dashboard.TotalRevenue = 0;

    return dashboard;
}

    public async Task<IEnumerable<Student>> GetAllStudentsAsync()
{
    var data = await _studentRepository.GetAllAsync();
    return data ?? Enumerable.Empty<Student>();
}

    public async Task<Student?> GetStudentByIdAsync(int id)
    {
        return await _studentRepository.GetByIdAsync(id);
    }

    public async Task<bool> CreateStudentAsync(Student student)
    {
        if (await _studentRepository.EmailExistsAsync(student.Email))
            return false;

        student.CreatedAt = DateTime.Now;
        student.JoinDate = DateOnly.FromDateTime(DateTime.Now);

        await _studentRepository.InsertAsync(student);
        await _studentRepository.SaveAsync();
        return true;
    }

   public async Task<bool> UpdateStudentAsync(Student student)
{
    var existing = await _studentRepository.GetByIdAsync(student.StudentId);
    if (existing == null) return false;

    existing.FullName = student.FullName;
    existing.Email = student.Email;
    existing.Phone = student.Phone;
    existing.Status = student.Status;

    _studentRepository.Update(existing); // ✅ REQUIRED NOW
    await _studentRepository.SaveAsync();

    return true;
}
    public async Task<bool> DeleteStudentAsync(int id)
    {
        var student = await _studentRepository.GetStudentWithEnrollmentsAsync(id);
        if (student == null || student.Enrollments.Any())
            return false;

        _studentRepository.Delete(student);
        await _studentRepository.SaveAsync();
        return true;
    }

    public async Task<bool> EmailExistsAsync(string email)
    {
        return await _studentRepository.EmailExistsAsync(email);
    }

    public async Task<Student?> GetStudentWithEnrollmentsAsync(int id)
    {
        return await _studentRepository.GetStudentWithEnrollmentsAsync(id);
    }
}