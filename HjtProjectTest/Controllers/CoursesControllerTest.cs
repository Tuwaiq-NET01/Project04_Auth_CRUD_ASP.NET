using HjtProject.Controllers;
using HjtProject.Data;
using HjtProject.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HjtProjectTest.Controller
{
    class CoursesControllerTest
    {
        private CoursesController coursesController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
       .UseInMemoryDatabase(databaseName: "ProjectSell").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            coursesController = new CoursesController(context);
            seed(context);
        }
        [Test]
        public void Check_if_id_is_minus_Test()
        {
            Assert.IsTrue(coursesController.Check_Minus(-1)); 
        }
        [Test]
        public void Check_if_id_is_not_minus_Test()
        {
            Assert.False(coursesController.Check_Minus(1));
        }
     
        public void seed(ApplicationDbContext context)
        {
            var courses = new[]
            {
                new CourseModel() {Id = 1,description="nice",InstructorId=1,name="new",price="2",pic=""},
                new CourseModel() {Id = 2,description="nice2",InstructorId=2,name="new2",price="2",pic=""},
               
            };
            context.Courses.AddRange(courses);
            context.SaveChanges();
        }
    }
}
