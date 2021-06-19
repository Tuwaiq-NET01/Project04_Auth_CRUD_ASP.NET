using GiftShop.Controllers;
using GiftShop.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GiftShopTest.Controllers
{
    [TestFixture]
    class FlowersControllerTest
    {
        private readonly ApplicationDbContext _context;

        [Test]
        public void Index_ReturnsIndexView()
        {
            // Arrange
            FlowersController controller = new FlowersController(_context);

            // Act
            var result = (RedirectToRouteResult)controller.Details(null);

            // Assert
            Assert.AreEqual(result.RouteValues["action"], "Details");

        }
    }
}
