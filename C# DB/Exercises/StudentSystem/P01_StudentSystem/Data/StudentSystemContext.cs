
namespace P01_StudentSystem.Data
{
    using Microsoft.EntityFrameworkCore;
    using P01_StudentSystem.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options) 
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Homework> HomeworkSubmissions { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<StudentCourse> StudentCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(s =>
            {
                s.Property(p => p.PhoneNumber)
                .HasColumnType("char(10)")
                .IsUnicode(false);


                s.HasMany(h => h.HomeworkSubmissions)
                .WithOne(st => st.Student)
                .HasForeignKey(h => h.HomeworkId);

            });

            modelBuilder.Entity<Resource>(r =>
            {
                r.Property(u => u.Url)
                .IsUnicode(false);

            });

            modelBuilder.Entity<Course>(c =>
            {
                c.HasMany(h => h.HomeworkSubmissions)
                .WithOne(ck => ck.Course)
                .HasForeignKey(h => h.HomeworkId);
            });

            modelBuilder.Entity<StudentCourse>(c =>
            {
                c.HasKey(k => new {k.CourseId , k.StudentId });
                
            });
            
        }
    }
}
