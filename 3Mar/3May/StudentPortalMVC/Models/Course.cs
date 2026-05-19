using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentPortalMVC.Models;

[Index("Title", Name = "IX_Courses_Title")]
public partial class Course
{
    [Key]
    public int CourseId { get; set; }

    [StringLength(150)]
    public string Title { get; set; } = null!;

    public int DurationDays { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Fee { get; set; }

    [StringLength(30)]
    public string Level { get; set; } = null!;

    public bool IsActive { get; set; }

    public DateTime CreatedAt { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Enrollment> Enrollments { get; set; } = new List<Enrollment>();
}
