using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AuthRBAC_MVC.Models;

public partial class AuthRBAC_DBContext : DbContext
{
    public AuthRBAC_DBContext()
    {
    }

    public AuthRBAC_DBContext(DbContextOptions<AuthRBAC_DBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<LoginLog> LoginLogs { get; set; }

    public virtual DbSet<Module> Modules { get; set; }

    public virtual DbSet<PasswordReset> PasswordResets { get; set; }

    public virtual DbSet<Permission> Permissions { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<RoleModule> RoleModules { get; set; }

    public virtual DbSet<RolePermission> RolePermissions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=POLLY\\SQLEXPRESS;Database=AuthRBAC_DB;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LoginLog>(entity =>
        {
            entity.HasKey(e => e.LogId).HasName("PK__LoginLog__5E5486488FE049D5");

            entity.Property(e => e.Ipaddress)
                .HasMaxLength(50)
                .HasColumnName("IPAddress");
            entity.Property(e => e.LoginTime).HasColumnType("datetime");
            entity.Property(e => e.LogoutTime).HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.LoginLogs)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__LoginLogs__UserI__75A278F5");
        });

        modelBuilder.Entity<Module>(entity =>
        {
            entity.HasKey(e => e.ModuleId).HasName("PK__Modules__2B7477A72778353C");

            entity.Property(e => e.ActionName).HasMaxLength(100);
            entity.Property(e => e.ControllerName).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ModuleName).HasMaxLength(100);
        });

        modelBuilder.Entity<PasswordReset>(entity =>
        {
            entity.HasKey(e => e.ResetId).HasName("PK__Password__783CF04DF198AB8B");

            entity.Property(e => e.ExpiryTime).HasColumnType("datetime");
            entity.Property(e => e.ResetToken).HasMaxLength(255);

            entity.HasOne(d => d.User).WithMany(p => p.PasswordResets)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__PasswordR__UserI__787EE5A0");
        });

        modelBuilder.Entity<Permission>(entity =>
        {
            entity.HasKey(e => e.PermissionId).HasName("PK__Permissi__EFA6FB2FF0E14C5C");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.PermissionName).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Roles__8AFACE1AD4524B35");

            entity.HasIndex(e => e.RoleName, "UQ__Roles__8A2B61600228585E").IsUnique();

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<RoleModule>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RoleModu__3214EC07D291A56D");

            entity.HasOne(d => d.Module).WithMany(p => p.RoleModules)
                .HasForeignKey(d => d.ModuleId)
                .HasConstraintName("FK__RoleModul__Modul__72C60C4A");

            entity.HasOne(d => d.Role).WithMany(p => p.RoleModules)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RoleModul__RoleI__71D1E811");
        });

        modelBuilder.Entity<RolePermission>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__RolePerm__3214EC07A1DA2847");

            entity.HasOne(d => d.Permission).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.PermissionId)
                .HasConstraintName("FK__RolePermi__Permi__6C190EBB");

            entity.HasOne(d => d.Role).WithMany(p => p.RolePermissions)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__RolePermi__RoleI__6B24EA82");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4C24049C13");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E4676A4FA8").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Users__A9D105342DF1CD3C").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.PasswordHash).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__UserRole__3214EC07B6C4E65E");

            entity.HasOne(d => d.Role).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.RoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRoles__RoleI__66603565");

            entity.HasOne(d => d.User).WithMany(p => p.UserRoles)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__UserRoles__UserI__656C112C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
