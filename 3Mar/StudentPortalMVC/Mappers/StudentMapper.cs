using StudentPortalMVC.Models;
using StudentPortalMVC.DTOs;

namespace StudentPortalMVC.Services.Mappers;

public static class StudentMapper
{
    public static StudentDto ToDto(Student student)
    {
        return new StudentDto
        {
            StudentId = student.StudentId,
            FullName = student.FullName,
            Email = student.Email,
            Phone = student.Phone,
            Status = student.Status,
            JoinDate = student.JoinDate
        };
    }

    public static Student ToEntity(StudentDto dto)
    {
        return new Student
        {
            StudentId = dto.StudentId,
            FullName = dto.FullName,
            Email = dto.Email,
            Phone = dto.Phone,
            Status = dto.Status,
            JoinDate = dto.JoinDate
        };
    }
}