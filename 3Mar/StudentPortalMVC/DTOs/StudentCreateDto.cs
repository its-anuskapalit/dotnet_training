namespace StudentPortalMVC.DTOs;

public class StudentCreateDto
{
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string Status { get; set; } = "Active";
}