using Book_Project.Controllers;
using Book_Project.Data;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_Project_Test.Controllers
{
    class BooksControllerTest
    {
        private readonly ApplicationDbContext _db;

        [Test]
        public void Action_Add_ViewResult()
        {
            BooksController books = new BooksController(_db);

            ViewResult view = books.Add() as ViewResult;

            Assert.AreEqual("Add", view.ViewName);
        }
    }
}
