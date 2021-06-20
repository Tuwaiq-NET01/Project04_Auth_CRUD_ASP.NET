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
    class ArtPiecesControllerTest
    {
        private readonly ApplicationDbContext _context;

        [Test]
        public void IndexArtTest()
        {
            //Arrange
            ArtPiecesController Art = new ArtPiecesController(_context);
            //Act
            ViewResult viewObj = Art.Index() as ViewResult;
            //Assert
            Assert.AreEqual("Index", viewObj.ViewName);

        }
    }
}
