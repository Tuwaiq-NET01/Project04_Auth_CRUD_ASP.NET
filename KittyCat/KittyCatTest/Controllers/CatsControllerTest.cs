using KittyCat.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KittyCatTest.Controllers
{
    [TestFixture]
    class CatsControllerTest
    {
        [Test]
        public void IndexTest()
        {
            //Arrange
            CatsController catsController = new CatsController();
            //Act
            //Assert
            Assert.Throws<NullReferenceException>( () => catsController.Index());
        }
    }
}
