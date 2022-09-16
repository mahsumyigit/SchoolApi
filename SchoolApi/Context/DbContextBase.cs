using System;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Reflection.Emit;
using SchoolApi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace SchoolApi.Context
{
    public class DbContextBase:DbContext
    {
        public DbSet<Student>? Students { get; set; }
        public DbSet<School>? Schools { get; set; }
        public DbSet<Teacher>? Teachers { get; set; }

        public DbContextBase(DbContextOptions<DbContextBase> options) :
        base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.UseSerialColumns();
        }


        public static void TableBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Surname).IsRequired();
                entity.Property(e => e.StudentNumber).IsRequired();
                entity.Property(e => e.Class).IsRequired();
                //entity.HasOne(e => e.School).WithMany(e => e!.Students).HasForeignKey(e => e.SchoolId);

            });
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name);
                entity.Property(e => e.Surname);
                entity.Property(e => e.Department);
                entity.Property(e => e.Description);
                //entity.HasMany(e => e.Students).WithMany(e => e.Teachers).UsingEntity(j => j.ToTable("teacher_student"));
                //entity.HasOne(e => e.School).WithMany(e => e!.Teachers).HasForeignKey(e => e.SchoolId);

            });
            modelBuilder.Entity<School>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired();
                entity.Property(e => e.Description);
                entity.Property(e => e.Type);
            });
        }
    }
}

