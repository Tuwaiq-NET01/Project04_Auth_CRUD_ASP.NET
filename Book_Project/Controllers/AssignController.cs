using Book_Project.Data;
using Book_Project.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Book_Project.Controllers
{
    public class AssignController : Controller
    {

        private readonly ApplicationDbContext _db;

        public AssignController(ApplicationDbContext db)
        {
            _db = db;
        }


        //GET - /Assign/Assign
        public IActionResult Assign()
        {

            return View("Assign");
        }

        //POST - /Assign/Assign
        [HttpPost]
        public IActionResult Assign([Bind("Book_ID", "BookStore_ID")] BookStore_Book_Model AssignedStore_Book)
        {
            //Another way for bind the data posted to database
            /*_db.Books.Add(new BookModel() {Id=book.Id ,Name=book.Name,Image=book.Image,Description=book.Description,
            AuthorId=book.AuthorId,PublisherId=book.PublisherId
            });*/

            if (ModelState.IsValid)
            {
                _db.BookStores_Books.Add(AssignedStore_Book);
                _db.SaveChanges();
                return RedirectToAction("Index","Stores");
            }

            return View();
        }
    }
}
