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
    public class TeachersControllerTest
    {
        private DbContextOptions<ApplicationDbContext> dbContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: "School")
            .Options;
        private TeachersController controller;

        [OneTimeSetUp]
        public void SetUp()
        {
            SeedDb();

            controller = new TeachersController(new ApplicationDbContext(dbContextOptions));
        }

        private void SeedDb()
        {
            var context = new ApplicationDbContext(dbContextOptions);
            var teachers = new List<Teacher>
            {
                new Teacher {TeacherId = 1, FirstName = "Abdulmajeed", LastName = "Almaymuni", Email="aaa@bbb.com"},
                new Teacher {TeacherId = 2, FirstName = "Ahmed", LastName = "Almaymuni", Email="ccc@ddd.com"},
                new Teacher {TeacherId = 3, FirstName = "Abdullah", LastName = "Almaymuni", Email="eee@fff.com"}
            };
            context.AddRange(teachers);
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
             * and one for teachers
             */
            Assert.AreEqual(3, result.ViewData.Count());


            /*
             * Expecting 3 Teachers to be in viewdata
             */

            Assert.AreEqual(3, ((List<Teacher>)result.ViewData["Teachers"]).Count);

        }
    }
}
