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
    public class StudentsControllerTest
    {

        private DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "School")
            .Options;
        private StudentsController controller;

        [OneTimeSetUp]
        public void SetUp()
        {
            SeedDb();

            controller = new StudentsController(new ApplicationDbContext(dbContextOptions));
        }

        private void SeedDb()
        {
            var context = new ApplicationDbContext(dbContextOptions);
            var students = new List<Student>
            {
                new Student {StudentId = 1, FirstName = "Abdulmajeed", LastName = "Almaymuni", Email="aaa@bbb.com"},
                new Student {StudentId = 2, FirstName = "Ahmed", LastName = "Almaymuni", Email="ccc@ddd.com"}
            };
            context.AddRange(students);
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
             * and one for students
             */
            Assert.AreEqual(3, result.ViewData.Count());


            /*
             * Expecting 2 Students to be in viewdata
             */
            
            Assert.AreEqual(2, ((List<Student>)result.ViewData["Students"]).Count);

        }


    }
}
