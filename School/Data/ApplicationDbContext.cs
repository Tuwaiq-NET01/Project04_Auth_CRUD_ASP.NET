using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using School.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace School.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Room> Rooms { get; set; }

        public DbSet<StudentTeacher> StudentTeachers { get; set; }
        public DbSet<TeacherCourse> TeacherCourses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Call base method for OnModelCreating in identity
            base.OnModelCreating(modelBuilder);

            //Make Composite keys
            modelBuilder.Entity<StudentTeacher>().HasKey(st => new { st.StudentId, st.TeacherId });
            modelBuilder.Entity<TeacherCourse>().HasKey(tc => new { tc.TeacherId, tc.CourseId });
        }

    }
}
