using FinalProject.Controllers;
using FinalProject.Data;
using FinalProject.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectTest.Controllers
{
    [TestClass]
    public class ProfileControllerTest
    {
        private ProfileController profileController;



        [TestMethod]
        public void Get_Msg_With_Id()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "Prof").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
            profileController = new ProfileController(context);
            seed(context);
            ProfileModel prof = profileController.Get()[0];
            ProfileModel expected = new ProfileModel()
            { Id = 3, DisplayName = "FAS", PhoneNomber = "321" };
            Microsoft.VisualStudio.TestTools.UnitTesting.Assert.AreEqual(expected.DisplayName, prof.DisplayName);
        }

        public void seed(ApplicationDbContext context)
        {
            var all = new[]
            {
                 new ProfileModel(){ Id = 3,  DisplayName = "FAS", PhoneNomber = "321" }
        };
            context.Profiles.AddRange(all);
            context.SaveChanges();
        }
    }
}
