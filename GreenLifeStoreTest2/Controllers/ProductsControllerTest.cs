using GreenLifeStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;

namespace GreenLifeStoreTest
{
    [TestFixture]
    public class ProductsControllerTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Details2_Return__NotFound_View_When_Id_Is_Null()
        {
            // Arrange
            var controller = new ProductsController(null);
            //Act
            ViewResult viewResultObj = controller.Details2(id: null) as ViewResult;
            //Assert
            Assert.AreEqual("_NotFound", viewResultObj.ViewName);
        }

    }
}
