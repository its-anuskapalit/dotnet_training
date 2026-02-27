using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ScoreDbMVC.Models;

namespace ScoreDbMVC.Data;

public partial class TrainingDBContext : DbContext
{
    public TrainingDBContext()
    {
    }

    public TrainingDBContext(DbContextOptions<TrainingDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Employees> Employees { get; set; }

    public virtual DbSet<Project> Project { get; set; }

    public virtual DbSet<Scores> Scores { get; set; }

    public virtual DbSet<_new> _new { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=POLLY\\SQLEXPRESS;Initial Catalog=TrainingDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Employees>(entity =>
        {
            entity.HasKey(e => e.EmployeeId).HasName("PK__Employee__7AD04F1168C9EFC9");

            entity.Property(e => e.Department).HasMaxLength(60);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Salary).HasColumnType("decimal(12, 2)");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Project__3214EC07BF98286C");

            entity.Property(e => e.Name).HasMaxLength(100);

            entity.HasOne(d => d.Employee).WithMany(p => p.Project)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Project_Employee");
        });

        modelBuilder.Entity<Scores>(entity =>
        {
            entity.HasNoKey();
        });

        modelBuilder.Entity<_new>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__new__3214EC073CFA834E");

            entity.ToTable("new");

            entity.Property(e => e.name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
