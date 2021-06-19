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
    class SweetsControllerTest
    {
        private readonly ApplicationDbContext _context;

        [Test]
        public void Index_ReturnsIndexView()
        {
            //Arrange
            SweetsController sweets = new SweetsController(_context);

            //Act
            ViewResult viewResultObj = sweets.Index() as ViewResult;

            //Assert
            NUnit.Framework.Assert.AreEqual("Index", viewResultObj.ViewName);

        }
    }
}
