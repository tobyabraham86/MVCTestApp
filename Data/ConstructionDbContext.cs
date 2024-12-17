using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace MVCTestApp.Data;

public partial class ConstructionDbContext : DbContext
{
    public ConstructionDbContext(DbContextOptions<ConstructionDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<ConstructionProject> ConstructionProjects { get; set; }

    public virtual DbSet<ConstructionStaff> ConstructionStaffs { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ConstructionProject>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Construc__3214EC27BB323A6B");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ProjectDetails).HasMaxLength(500);
            entity.Property(e => e.ProjectLocation).HasMaxLength(100);
            entity.Property(e => e.ProjectName).HasMaxLength(100);
            entity.Property(e => e.ProjectStatus).HasMaxLength(50);
        });

        modelBuilder.Entity<ConstructionStaff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Construc__96D4AAF71A81E7E7");

            entity.ToTable("ConstructionStaff");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.EmploymentStatus).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.JobTitle).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
