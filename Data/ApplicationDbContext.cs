// Data/ApplicationDbContext.cs

using Microsoft.EntityFrameworkCore;
using DMS_Audit_MVC.Models;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace DMS_Audit_MVC.Data;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Criteria> Criterias { get; set; }
    public DbSet<CriteriaState> CriteriaStates { get; set; }
    public DbSet<Level> Levels { get; set; }
    public DbSet<LevelState> LevelStates { get; set; }
    public DbSet<Project> Projects { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure relationships and constraints here if needed
        // Example:
        // modelBuilder.Entity<CriteriaState>()
        //     .HasOne(cs => cs.Criteria)
        //     .WithMany()
        //     .HasForeignKey(cs => cs.CriteriaID);

        base.OnModelCreating(modelBuilder);
    }
}
