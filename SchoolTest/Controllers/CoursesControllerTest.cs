using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using School.Controllers;
using School.Data;
using School.Models;

namespace SchoolTest.Controllers
{
    [TestFixture]
    public class CoursesControllerTest
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "School")
            .Options;
        private CoursesController controller;

        [OneTimeSetUp]
        public void SetUp()
        {
            SeedDb();

            controller = new CoursesController(new ApplicationDbContext(dbContextOptions));
        }

        private void SeedDb()
        {
            var context = new ApplicationDbContext(dbContextOptions);
            var courses = new List<Course>
            {
                new Course {CourseId = 1, Title="Math" },
                new Course {CourseId = 2, Title="Physics" },
                new Course {CourseId = 3, Title="English" },
                new Course {CourseId = 4, Title="History" }
            };
            context.AddRange(courses);
            context.SaveChanges();
        }

        [Test]
        public void IndexTest_WithData()
        {
            var result = controller.Index() as ViewResult;

            /*
             * Expecting Viewdata to contain 3 different values
             * one for added
             * one for deleted
             * and one for courses
             */
            Assert.AreEqual(3, result.ViewData.Count());


            /*
             * Expecting 4 Courses to be in viewdata
             */

            Assert.AreEqual(4, ((List<Course>)result.ViewData["Courses"]).Count);

        }

    }
}
