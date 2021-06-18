using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NuGet;


namespace TechME_Dashbord.Test.Controllers
{
    class CoursesControllers
    {
        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
           .UseInMemoryDatabase(databaseName: "Tchess").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
        }
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
    }
}
