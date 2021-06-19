using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Pets_Houses.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pets_Houses.Controllers.Tests
{
    [TestClass()]
    public class PetsControllerTests
    {
        [TestMethod()]
        public void CreateTest()
        {
            PetsController controller = new PetsController(null);
            //Act
            ViewResult result = controller.Create() as ViewResult;
            //Assert
            Assert.IsNotNull(result);

        }
    }
}