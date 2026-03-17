namespace StudentPortalMVC.DTOs;

public class StudentUpdateDto
{
    public int StudentId { get; set; }
    public string FullName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Phone { get; set; }
    public string Status { get; set; } = null!;
}