using DarkWhiteCodeExhibition.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace DarkWhiteCodeExhibitionTest
{
    [TestClass]
    public class UnitTest1
    {
        //private 
        [SetUp]
     /*   public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
     .UseInMemoryDatabase(databaseName: "DarkCodeTest").Options;
            var context = new ApplicationDbContext(options);
            context.Database.EnsureDeleted();
        }
        public void seed(ApplicationDbContext context)
        {

        }*/
        [Test]
        public void Test1()
        {
            Assert.Pass();
        }
      ////  [TestMethod]
      ////  public void TestMethod1()
       // {
       // }
    }
}
