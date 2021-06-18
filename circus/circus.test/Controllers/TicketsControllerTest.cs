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
    class TicketsControllerTest
    {
        [Test]
        public void indexTest_NullPage()
        {
            circus.Controllers.TicketsController tickets = new(null);
            ViewResult result = tickets.Index() as ViewResult;

            Assert.IsNull(result.ViewName);
        }
    }
}
