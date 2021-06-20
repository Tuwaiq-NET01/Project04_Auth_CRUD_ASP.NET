using GreenLifeStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace GreenLifeStoreTest
{
    [TestFixture]
    public class BranchesControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Branches_Return_Index_View()
        {
            // Arrange
            BranchesController controller = new BranchesController(null);
            //Act
            ViewResult viewResultObj = (ViewResult)controller.BranchesIndex();
            //Assert
            Assert.AreEqual("Index", viewResultObj.ViewName);
        }
    }
}





