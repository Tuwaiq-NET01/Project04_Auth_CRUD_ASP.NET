using DarkWhiteCodeExhibition.Controllers;
using DarkWhiteCodeExhibition.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assert = NUnit.Framework.Assert;

namespace DarkWhiteCodeExhibitionTest.Controllers
{
    [TestFixture]
    class ChairControllerTest
    {
        private readonly ApplicationDbContext _context;

        [Test]
        public void IndexChair()
        {
            //Arrange
            ChairController Art = new ChairController(_context);
            //Act
            ViewResult viewObj = Art.Index() as ViewResult;
            //Assert
            Assert.AreEqual("Index", viewObj.ViewName);

        }
    }
}
    

