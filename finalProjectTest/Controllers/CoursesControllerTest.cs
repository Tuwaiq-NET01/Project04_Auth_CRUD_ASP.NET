using finalProject.Controllers;
using finalProject.Data;
using finalProject.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finalProjectTest.Controllers
{
    [TestFixture]
    class CoursesControllerTest
    {
        [Test]
        public void Execute_Should_Return_All_Courses()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "CoursesTest").Options;
            var context = new ApplicationDbContext(options);
            Seed(context);
            //Act
            var query = new CoursesController(context);
            var result = query.Execute();
            //Assert
            /*context.Database.EnsureDeleted();*/
            Assert.AreEqual(3, result.Count);
        }
        private void Seed(ApplicationDbContext context)
        {
            var Courses = new[]
            {
             new CoursesModel {subject="Dot Net"},
             new CoursesModel {subject="React"},
             new CoursesModel {subject="Unit Test"},
           
            };
            context.Courses.AddRange(Courses);
            context.SaveChanges();
        }
    }
}


