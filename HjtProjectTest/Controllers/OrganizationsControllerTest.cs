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
    class OrganizationsControllerTest
    {
        private OrganizationsController organizationsController;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
       .UseInMemoryDatabase(databaseName: "ProjectSell").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            organizationsController = new OrganizationsController(context);
            seed(context);
        }

        [Test]
        public void Check_id_available_Test()
        {
            Assert.IsTrue(organizationsController.Check_if_in_database(1));
        }

        [Test]
        public void Check_id_Unvailable_Test()
        {
            Assert.False(organizationsController.Check_if_in_database(3));
        }
        public void seed(ApplicationDbContext context)
        {
            var organization = new[]
            {
                new OrganizationModel() {Id = 1,summary="nice",name="new",pic=""},
                new OrganizationModel() {Id = 2,summary="nice2",name="new2",pic=""},
            };
            context.Organizations.AddRange(organization);
            context.SaveChanges();
        }
    }
}
