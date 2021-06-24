using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TechME_Dashboard.Models;

namespace TechME_Dashboard.Data
{
    public class TechMEDbContext : IdentityDbContext
    {
        public TechMEDbContext(DbContextOptions<TechMEDbContext> options)
            : base(options)
        {
             
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<TraineeCoursesModel>()
            .HasKey(TC => new { TC.Course_ID, TC.Trainee_ID });
            
             modelBuilder.Entity<TraineeCoursesModel>()
                .HasOne<TraineeModel>(TC => TC.Trainee)
                .WithMany(T => T.TraineeCourses)
                .HasForeignKey(TC => TC.Trainee_ID)
                .OnDelete(DeleteBehavior.Cascade);
               

            modelBuilder.Entity<TraineeCoursesModel>()
               .HasOne<CourseModel>(TC => TC.Course)
               .WithMany(C => C.TraineeCourses)
               .HasForeignKey(TC => TC.Course_ID)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TraineeInstructorModel>()
                .HasOne<TraineeModel>(T => T.Trainee)
                .WithMany(I => I.TraineeInstructor)
                .HasForeignKey(TI => TI.Trainee_ID)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<TraineeInstructorModel>()
                .HasOne<InstructorModel>(I =>I.Instructor)
                .WithMany(I => I.TraineeInstructor)
                .HasForeignKey(TI => TI.Instructor_ID)
                .OnDelete(DeleteBehavior.Cascade);
/*
            modelBuilder.Entity<InstructorModel>()
                .HasMany<CourseModel>(C => C.Courses)
                .WithOne(I => I.Instructor)
                .OnDelete(DeleteBehavior.Cascade);*/

            base.OnModelCreating(modelBuilder);

        }


        public DbSet<ContactModel> ContactUs { get; set; }
        public DbSet<CourseModel> Course { get; set; }
        public DbSet<InstructorModel> Instructor { get; set; }
        public DbSet<TraineeModel> Trainee { get; set; }
        public DbSet<TraineeCoursesModel> TraineeCourses { get; set; }
        public DbSet<TraineeInstructorModel> TraineeInstructors { get; set; }

    }
}