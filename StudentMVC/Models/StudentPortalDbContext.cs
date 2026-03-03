using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentPortalMvc.Models;

public partial class StudentPortalDbContext : DbContext
{
    public StudentPortalDbContext()
    {
    }

    public StudentPortalDbContext(DbContextOptions<StudentPortalDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Enrollment> Enrollments { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<TblLog> TblLogs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=POLLY\\SQLEXPRESS;Database=StudentPortalDb;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())", "DF_Courses_CreatedAt");
            entity.Property(e => e.IsActive).HasDefaultValue(true, "DF_Courses_IsActive");
        });

        modelBuilder.Entity<Enrollment>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())", "DF_Enrollments_CreatedAt");
            entity.Property(e => e.PaymentStatus).HasDefaultValue("Pending", "DF_Enrollments_PaymentStatus");

            entity.HasOne(d => d.Course).WithMany(p => p.Enrollments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollments_Courses");

            entity.HasOne(d => d.Student).WithMany(p => p.Enrollments)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Enrollments_Students");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.CreatedAt).HasDefaultValueSql("(sysdatetime())", "DF_Students_CreatedAt");
            entity.Property(e => e.Status).HasDefaultValue("Active", "DF_Students_Status");
        });

        modelBuilder.Entity<TblLog>(entity =>
        {
            entity.Property(e => e.LogId).ValueGeneratedNever();

            entity.HasOne(d => d.Student).WithMany(p => p.TblLogs)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_tblLog_Students");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
