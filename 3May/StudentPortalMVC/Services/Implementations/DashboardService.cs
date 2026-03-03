using Microsoft.EntityFrameworkCore;
using StudentPortalMVC.Data;
using StudentPortalMVC.Services.Interfaces;
using StudentPortalMVC.ViewModels;

namespace StudentPortalMVC.Services.Implementations;

public class DashboardService : IDashboardService
{
    private readonly StudentPortalDbContext _context;

    public DashboardService(StudentPortalDbContext context)
    {
        _context = context;
    }

    public async Task<DashboardVM> GetDashboardDataAsync()
    {
        var vm = new DashboardVM();

        vm.TotalStudents = await _context.Students.CountAsync();

        vm.ActiveCourses = await _context.Courses
            .CountAsync(c => c.IsActive == true);

        vm.TotalEnrollments = await _context.Enrollments.CountAsync();

        vm.TotalRevenue = await _context.Enrollments
            .SumAsync(e => (decimal?)e.PaidAmount) ?? 0;

        vm.RecentEnrollments = await _context.Enrollments
            .Include(e => e.Student)
            .Include(e => e.Course)
            .OrderByDescending(e => e.EnrollDate)
            .Take(5)
            .Select(e => new RecentEnrollmentVM
            {
                StudentName = e.Student.FullName,
                CourseTitle = e.Course.Title,
                EnrollDate = e.EnrollDate.ToDateTime(TimeOnly.MinValue),
                PaymentStatus = e.PaymentStatus,
                PaidAmount = e.PaidAmount
            })
            .ToListAsync();

        return vm;
    }
}