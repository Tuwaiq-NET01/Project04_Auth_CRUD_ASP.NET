using finalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace finalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<CoursesModel> Courses { get; set; }
        public DbSet<InstructorModel> Instructors { get; set; }
        public DbSet<InfoModel> Information { get; set; }
        public DbSet<ProfileModel> Profiles { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            //seeding  Courses
            modelBuilder.Entity<CoursesModel>().HasData(new CoursesModel { id = 1, subject="Dot Net" });
            modelBuilder.Entity<CoursesModel>().HasData(new CoursesModel { id = 2, subject = "React" });
            modelBuilder.Entity<CoursesModel>().HasData(new CoursesModel { id = 3, subject = "Design patterns" });
            modelBuilder.Entity<CoursesModel>().HasData(new CoursesModel { id = 4, subject = "Unit testing" });
       
            //seeding  Instructor
            modelBuilder.Entity<InstructorModel>().HasData(new InstructorModel { id = 1, name = "sami", email = "sami@gmail.com"  });
            modelBuilder.Entity<InstructorModel>().HasData(new InstructorModel { id = 2, name = "ghada", email = "ghada@gmail.com" });
            modelBuilder.Entity<InstructorModel>().HasData(new InstructorModel { id = 3, name = "lamyaa", email = "lamyaa@gmail.com"  });
            modelBuilder.Entity<InstructorModel>().HasData(new InstructorModel { id = 4, name = "fai", email = "fai@gmail.com" });

            //seeding  Files
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 3, name = "Lecture three week 4", date = new DateTime(2021, 5, 23), course_id = 1 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 4, name = "Lecture four week 4", date = new DateTime(2021, 5, 24), course_id = 1 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 5, name = "Lecture five week 4", date = new DateTime(2021, 5, 25), course_id = 1 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 8, name = "Lecture three week 4", date = new DateTime(2021, 5, 23),  course_id = 2 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 9, name = "Lecture four week 4", date = new DateTime(2021, 5, 24),  course_id = 2 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 10, name = "Lecture five week 4", date = new DateTime(2021, 5, 25), course_id = 2 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 13, name = "Lecture three week 4", date = new DateTime(2021, 5, 23),  course_id = 3 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 14, name = "Lecture four week 4", date = new DateTime(2021, 5, 24),  course_id = 3 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 15, name = "Lecture five week 4", date = new DateTime(2021, 5, 25),  course_id = 3 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 18, name = "Lecture three week 4", date = new DateTime(2021, 5, 23),  course_id = 4 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 19, name = "Lecture four week 4", date = new DateTime(2021, 5, 24),  course_id = 4 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 20, name = "Lecture five week 4", date = new DateTime(2021, 5, 25),  course_id = 4 });



        }
    }
}
 