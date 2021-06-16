using circus.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace circus.test.Controllers
{
    [TestFixture]
    class GalleryControllerTest
    {
        [Test]
        public void indexTest_ShowGalleryPage()
        {
            //arrange
            PerformerModel per = new PerformerModel { Id = 99, Name = "name", Image="img", Profession="prof"};
            circus.Controllers.GalleryController gallery = new(null);
            ViewResult result = gallery.Index() as ViewResult;
            Assert.IsNull(result.ViewName);
        }
    }
}
