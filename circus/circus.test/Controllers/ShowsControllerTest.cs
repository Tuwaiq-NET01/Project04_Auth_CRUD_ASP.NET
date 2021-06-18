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
    class ShowsControllerTest
    {
        [Test]
        public void indexTest_NullPageView()
        {
            circus.Controllers.ShowsController shows = new(null);
            ViewResult result = shows.Index() as ViewResult;

            Assert.IsNull(result.ViewName);
        }
    }
}
