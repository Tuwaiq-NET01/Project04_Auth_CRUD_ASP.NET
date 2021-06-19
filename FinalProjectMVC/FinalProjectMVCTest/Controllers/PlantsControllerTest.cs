using FinalProjectMVC.Controllers;
using FinalProjectMVC.Data;
using FinalProjectMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectMVCTest.Controllers
{
    [TestFixture]
    class PlantsControllerTest
    {
        [Test] // test Edit2 action Plant Controller
        public void Edit2_Return__NotFound_View_When_Id_Is_Null()
        {
            // Arrange
            var controller = new PlantsController(null);
            //Act
            ViewResult viewResultObj = controller.Edit2(id: null) as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("_NotFound", viewResultObj.ViewName);
        }

        [Test]
        public void Execute_Should_Return_All_Plants()
        {
            //Arrange
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "plantTest").Options;
            var context = new ApplicationDbContext(options);
            Seed(context);
            //Act
            var query = new PlantsController(context);
            var result = query.Execute();
            //Assert
            /*context.Database.EnsureDeleted();*/
            Assert.AreEqual(5, result.Count);
        }

        private void Seed(ApplicationDbContext context)
        {
            var plants = new[]
            {
             new PlantModel {PlantName="Rosemary"},
             new PlantModel {PlantName="Basil"},
             new PlantModel {PlantName="Fix"},
             new PlantModel {PlantName="Kaluna"},
             new PlantModel {PlantName="Olive Tree"},
            };
            context.Plants.AddRange(plants);
            context.SaveChanges();
        }
    }
}
