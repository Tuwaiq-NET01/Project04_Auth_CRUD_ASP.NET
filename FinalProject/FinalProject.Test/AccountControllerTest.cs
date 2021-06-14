using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Test
{
    class AccountControllerTest
    {
        [Test]
        public  void Register_CanRenderIndexView_ReturnsTrue()
        {
            FinalProject.Controllers.AccountController acc = new Controllers.AccountController(null, null);
            ViewResult result =  acc.Index() as ViewResult;

            Assert.IsNull(result.ViewName);
        }
    }
}
