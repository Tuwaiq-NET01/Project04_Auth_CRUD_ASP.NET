using HHealthChoice_Proj4.Controllers;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChoice_Proj4Test.Controllers
{
    [TestFixture]
    class FavouriteControllerTest
    {
        [Test]
        public void Index_ThrowEx()
        {
            //Arrange
            FavouriteController favouriteController = new FavouriteController();
            
            //Assert
            NUnit.Framework.Assert.Throws<NullReferenceException>(() => favouriteController.Delete(id: null));
        }
    }
}
