using GreenLifeStore.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GreenLifeStoreTests.Controllers
{
    [TestFixture]
    public class ProductsControllerTest
    {
        [Test]
        public void Details2_Return__NotFound_View_When_Id_Is_Null()
        {
            // Arrange
            var controller = new ProductsController(null);
            //Act
            ViewResult viewResultObj = controller.Details2(id: null) as ViewResult;
            //Assert
            NUnit.Framework.Assert.AreEqual("_NotFound", viewResultObj.ViewName);
        }

    }
}
