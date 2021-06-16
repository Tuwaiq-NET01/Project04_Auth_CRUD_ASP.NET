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
        public DbSet<StudentModel> Students { get; set; }
        public DbSet<CoursesModel> Courses { get; set; }
        public DbSet<Files_UploadedModel> Files { get; set; }
        public DbSet<InstructorModel> Instructors { get; set; }
        public DbSet<CommentModel> Comments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //seeding  Students
            modelBuilder.Entity<StudentModel>().HasData(new StudentModel {id = 1, name = "Afra", email = "Afra@gmail.com" });
            modelBuilder.Entity<StudentModel>().HasData(new StudentModel {id = 2 , name = "Norah", email = "Norah@mail.com" });
            modelBuilder.Entity<StudentModel>().HasData(new StudentModel {id = 3 , name = "taif", email = "taif@mail.com" });
            modelBuilder.Entity<StudentModel>().HasData(new StudentModel {id = 4, name = "sara", email = "sara@mail.com" });

            //seeding  Courses
            modelBuilder.Entity<CoursesModel>().HasData(new CoursesModel { id = 1, subject="Dot Net" });
            modelBuilder.Entity<CoursesModel>().HasData(new CoursesModel { id = 2, subject = "React" });
            modelBuilder.Entity<CoursesModel>().HasData(new CoursesModel { id = 3, subject = "Design patterns" });
            modelBuilder.Entity<CoursesModel>().HasData(new CoursesModel { id = 4, subject = "Unit testing" });
       
            //seeding  Instructor
            modelBuilder.Entity<InstructorModel>().HasData(new InstructorModel { id = 1, name = "sami", email = "sami@gmail.com" , course_id = 1 });
            modelBuilder.Entity<InstructorModel>().HasData(new InstructorModel { id = 2, name = "ghada", email = "ghada@gmail.com", course_id = 1 });
            modelBuilder.Entity<InstructorModel>().HasData(new InstructorModel { id = 3, name = "lamyaa", email = "lamyaa@gmail.com", course_id = 2 });
            modelBuilder.Entity<InstructorModel>().HasData(new InstructorModel { id = 4, name = "fai", email = "fai@gmail.com", course_id = 4 });

            //seeding  Comments
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { id = 1, CommentContent = "First comment here ", course_id = 1 });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { id = 2, CommentContent = "second comment here ", course_id = 1 });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { id = 3, CommentContent = "third comment here ", course_id = 1 });
            modelBuilder.Entity<CommentModel>().HasData(new CommentModel { id = 4, CommentContent = "First comment here ", course_id = 2 });

            //seeding  Files Number three
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 1, name = "Lecture One week 4", date = new DateTime(2021, 5, 21), student_id = 1, course_id = 1 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 2, name = "Lecture tow week 4", date = new DateTime(2021, 5, 22), student_id = 1, course_id = 1 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 3, name = "Lecture three week 4", date = new DateTime(2021, 5, 23), student_id = 1, course_id = 1 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 4, name = "Lecture four week 4", date = new DateTime(2021, 5, 24), student_id = 1, course_id = 1 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 5, name = "Lecture five week 4", date = new DateTime(2021, 5, 25), student_id = 1, course_id = 1 });

            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 6, name = "Lecture One week 4", date = new DateTime(2021, 5, 21), student_id = 1, course_id = 2 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 7, name = "Lecture tow week 4", date = new DateTime(2021, 5, 22), student_id = 1, course_id = 2 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 8, name = "Lecture three week 4", date = new DateTime(2021, 5, 23), student_id = 1, course_id = 2 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 9, name = "Lecture four week 4", date = new DateTime(2021, 5, 24), student_id = 1, course_id = 2 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 10, name = "Lecture five week 4", date = new DateTime(2021, 5, 25), student_id = 1, course_id = 2 });
           
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 11, name = "Lecture One week 4", date = new DateTime(2021, 5, 21), student_id = 1, course_id = 3 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 12, name = "Lecture tow week 4", date = new DateTime(2021, 5, 22), student_id = 1, course_id = 3 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 13, name = "Lecture three week 4", date = new DateTime(2021, 5, 23), student_id = 1, course_id = 3 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 14, name = "Lecture four week 4", date = new DateTime(2021, 5, 24), student_id = 1, course_id = 3 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 15, name = "Lecture five week 4", date = new DateTime(2021, 5, 25), student_id = 1, course_id = 3 });
            
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 16, name = "Lecture One week 4", date = new DateTime(2021, 5, 21), student_id = 1, course_id = 4 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 17, name = "Lecture tow week 4", date = new DateTime(2021, 5, 22), student_id = 1, course_id = 4 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 18, name = "Lecture three week 4", date = new DateTime(2021, 5, 23), student_id = 1, course_id = 4 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 19, name = "Lecture four week 4", date = new DateTime(2021, 5, 24), student_id = 1, course_id = 4 });
            modelBuilder.Entity<Files_UploadedModel>().HasData(new Files_UploadedModel { id = 20, name = "Lecture five week 4", date = new DateTime(2021, 5, 25), student_id = 1, course_id = 4 });



        }
    }
}
 