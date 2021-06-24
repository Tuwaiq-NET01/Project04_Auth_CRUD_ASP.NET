using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechME_Dashboard.Data;
using TechME_Dashboard.Controllers;
using NUnit.Framework;
using Microsoft.EntityFrameworkCore;
using TechME_Dashboard.Models;
using Microsoft.EntityFrameworkCore.InMemory;
using System.ComponentModel.DataAnnotations;


namespace TechME_Dashboard.Test.Controller
{
    class CoursesTest
    {
        private CoursesController coursesController;
   
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<TechMEDbContext>()
            .UseInMemoryDatabase(databaseName: "TeachME_Dashboard").Options;
            var context = new TechMEDbContext(options);
            context.Database.EnsureDeleted();
            coursesController = new CoursesController(context);
            Seeding(context);
        }
        
        [Test]
        public void ShouldCreateCourse()

        {//Arrange
            // var course = new CourseModel() { Course_ID = 4, Course_Name = "UnitTest", Course_Category = "Tasting", Course_Description = " What Is Unite Test?", Course_Image = "Image", Course_Start_Date = DateTime.Parse("2005-09-01"), Course_End_Date = DateTime.Parse("2005-09-01") };
            // coursesController.CreateCourse(course);
            // //Assert

            // Assert.AreEqual(expected:4,actual:coursesController.GetAllCourses().Count);
        }
         
        //Function for test Dsts
        private void Seeding(TechMEDbContext context)
        {
            var Courses = new[]
            {
                new CourseModel { Course_ID=1,Course_Name="AI", Course_Category="Tech",Course_Description="What is AI?", Course_Image="IMAGE" ,Course_End_Date=DateTime.Parse("2005-09-01"),Course_Start_Date=DateTime.Parse("2005-09-01")},
                 new CourseModel { Course_ID=2,Course_Name="C#", Course_Category="Programing Language",Course_Description="Intro To C#?", Course_Image="IMAGE" ,Course_End_Date=DateTime.Parse("2005-09-01"),Course_Start_Date=DateTime.Parse("2005-09-01")},
                  new CourseModel { Course_ID=3,Course_Name="Cyber Security", Course_Category=" Tehc",Course_Description="What is Cyber Security ?", Course_Image="IMAGE",Course_End_Date=DateTime.Parse("2005-09-01"),Course_Start_Date=DateTime.Parse("2005-09-01") }

            };
            context.Course.AddRange(Courses);
            context.SaveChanges();//Sve change TO The Database
        }


    }
}
