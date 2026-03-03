using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentPortalMvc.Models;

[Index("CourseId", Name = "IX_Enrollments_CourseId")]
[Index("StudentId", Name = "IX_Enrollments_StudentId")]
[Index("StudentId", "CourseId", Name = "UQ_Enrollments_StudentCourse", IsUnique = true)]
public partial class Enrollment
{
    [Key]
    public int EnrollmentId { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    public DateOnly EnrollDate { get; set; }

    [StringLength(20)]
    public string PaymentStatus { get; set; } = null!;

    [Column(TypeName = "decimal(10, 2)")]
    public decimal PaidAmount { get; set; }

    public DateTime CreatedAt { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Enrollments")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Enrollments")]
    public virtual Student Student { get; set; } = null!;
}
