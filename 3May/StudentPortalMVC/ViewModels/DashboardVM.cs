namespace StudentPortalMVC.ViewModels;

public class DashboardVM
{
    public int TotalStudents { get; set; }
    public int ActiveCourses { get; set; }
    public int TotalEnrollments { get; set; }
    public decimal TotalRevenue { get; set; }

    public List<RecentEnrollmentVM> RecentEnrollments { get; set; } = new();
}

public class RecentEnrollmentVM
{
    public string StudentName { get; set; } = "";
    public string CourseTitle { get; set; } = "";
    public DateTime EnrollDate { get; set; }
    public string PaymentStatus { get; set; } = "";
    public decimal PaidAmount { get; set; }
}