using Coffee.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoffeeTest.Controllers
{
    [TestFixture]
    class RoasteriesControllerTest
    {
            [Test]
            public void Details2_Roas_AreEqual()
            {
            //Arrange
            RoasteriesController roasteriesController = new RoasteriesController();

                //Act
                ViewResult viewResult = roasteriesController.Details2(id:null) as ViewResult;

                //Assert
                NUnit.Framework.Assert.AreEqual(null, viewResult.ViewName);

            }
        }
}
