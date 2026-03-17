using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApiCRUD.Models;

public partial class StudentDBContext : DbContext
{
    public StudentDBContext()
    {
    }

    public StudentDBContext(DbContextOptions<StudentDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC0764CE2030");

            entity.Property(e => e.FatherName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StudentGender)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.StudentName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
