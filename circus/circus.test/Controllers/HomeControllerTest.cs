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
    class HomeControllerTest
    {
        [Test]
        public void indexTest_ShowHomePage()
        {
            circus.Controllers.HomeController home = new(null);
            ViewResult result = home.Index() as ViewResult;

            Assert.IsNull(result.ViewName);
        }
    }
}
