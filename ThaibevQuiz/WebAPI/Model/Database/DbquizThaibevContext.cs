using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Model.Database;

public partial class DbquizThaibevContext : DbContext
{
    public DbquizThaibevContext()
    {
    }

    public DbquizThaibevContext(DbContextOptions<DbquizThaibevContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CountNumber> CountNumbers { get; set; }

    public virtual DbSet<FilesSystem> FilesSystems { get; set; }

    public virtual DbSet<TbComment> TbComments { get; set; }

    public virtual DbSet<TbEmployee> TbEmployees { get; set; }

    public virtual DbSet<TbPost> TbPosts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=10.5.56.35;Database=DBquizThaibev_byHam;User ID=sa;Password=P@ssw0rd;Encrypt=False;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CountNumber>(entity =>
        {
            entity.HasKey(e => e.CounterId).HasName("PK__CountNum__F12879C419BA45FA");

            entity.ToTable("CountNumber");

            entity.Property(e => e.CountNumber1).HasColumnName("CountNumber");
        });

        modelBuilder.Entity<FilesSystem>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("FilesSystem");

            entity.Property(e => e.FileName).HasMaxLength(500);
            entity.Property(e => e.Rowno).ValueGeneratedOnAdd();
            entity.Property(e => e.UploadDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TbComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__TbCommen__C3B4DFCAE34F4B79");

            entity.Property(e => e.Comment).HasMaxLength(500);
            entity.Property(e => e.CommentBy).HasMaxLength(500);

            entity.HasOne(d => d.Post).WithMany(p => p.TbComments)
                .HasForeignKey(d => d.PostId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_TbT_TbComments_TbPosts");
        });

        modelBuilder.Entity<TbEmployee>(entity =>
        {
            entity.HasKey(e => e.EmpCode).HasName("PK__TbEmploy__A0CDA1995656B754");

            entity.Property(e => e.EmpCode)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("empCode");
            entity.Property(e => e.ComName)
                .HasMaxLength(300)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("empName");
            entity.Property(e => e.EmpSurName)
                .HasMaxLength(300)
                .IsUnicode(false)
                .HasColumnName("empSurName");
            entity.Property(e => e.IsActive)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("isActive");
            entity.Property(e => e.PermisstionType)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        modelBuilder.Entity<TbPost>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__TbPosts__AA126018916D82B0");

            entity.Property(e => e.PostBy).HasMaxLength(500);
            entity.Property(e => e.PostDate).HasColumnType("datetime");
            entity.Property(e => e.Postimage).HasMaxLength(500);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
