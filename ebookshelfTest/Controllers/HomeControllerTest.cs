using eBookshelf.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebookshelfTest.Controllers
{
    class HomeControllerTest
    {
        private static readonly ILogger<HomeController> _logger;

        private HomeController homeController = new HomeController(_logger);

        [Test]

        public void HomeIndexReturnIndexView()
        {
            ViewResult viewObj = (ViewResult)homeController.Index();
            //Assert.IsNotNull(viewObj);
            Assert.IsTrue(string.IsNullOrEmpty(viewObj.ViewName) || viewObj.ViewName == "Index");
        }
        [Test]
        public void Check_if_id_is_not_minus_Test()
        {

            Assert.False(homeController.Check_Minus(1));
            Assert.True(homeController.Check_Minus(-1));
        }
    }
}
