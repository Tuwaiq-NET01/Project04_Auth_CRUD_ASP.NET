using Bookworm_Project.Controllers;
using Bookworm_Project.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookworm_ProjectTest.Controllers
{
    [TestFixture]
    class ReviewsControllerTest
    {
        [Test]
        public void unitTestAddReviewWithoutUserManger_ThrowEx()
        {
            ReviewsController ControllerObj = new ReviewsController(null,null);


            Assert.ThrowsAsync<NullReferenceException>(async () => await ControllerObj.AddAsync(new ReviewModel(), 1));
         
        }
    }       
}
