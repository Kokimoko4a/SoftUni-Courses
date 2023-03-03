using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Homework> Homeworks { get; set; }
        public DbSet<Resource> Resources { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<StudentCourse> StudentsCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
            {
                options.UseSqlServer(@"Server=DESKTOP-RFLPA5C\SQLEXPRESS;Database=Student_System;Integrated Security=true");
            }

            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

    modelBuilder.Entity<StudentCourse>(sc =>
            {
                sc.HasKey(k => new { k.StudentId, k.CourseId });

                sc.HasOne(s => s.Student)
                .WithMany(c => c.StudentsCourses)
                .HasForeignKey(x => x.StudentId);

                sc.HasOne(c => c.Course)
                .WithMany(s => s.StudentsCourses)
                .HasForeignKey(x => x.CourseId);
            });

            base.OnModelCreating(modelBuilder);
        }
    }
}
