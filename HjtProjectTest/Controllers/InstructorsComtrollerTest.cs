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

namespace HjtProjectTest.Controllers
{

    class CoursesControllerTest
    {
        private InstructorsController instructorsController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
       .UseInMemoryDatabase(databaseName: "ProjectSell").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            instructorsController = new InstructorsController(context);
            seed(context);
        }

        [Test]
        public void Check_id_available_Test()
        {
            Assert.IsTrue(instructorsController.Check_if_in_database(1));
        }

        [Test]
        public void Check_id_Unvailable_Test()
        {
            Assert.False(instructorsController.Check_if_in_database(3));
        }
        public void seed(ApplicationDbContext context)
        {
            var instructors = new[]
            {
                new InstructorModel() {Id = 1,summary="nice",OrganizationId=1,name="new",pic=""},
                new InstructorModel() {Id = 2,summary="nice2",OrganizationId=2,name="new2",pic=""},
            };
            context.Instructors.AddRange(instructors);
            context.SaveChanges();
        }
    }
    }
