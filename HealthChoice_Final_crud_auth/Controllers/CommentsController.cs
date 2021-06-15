using HealthChoice_Final_crud_auth.Data;
using HealthChoice_Final_crud_auth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


/*
namespace HealthChoice_Final_crud_auth.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CommentsController(ApplicationDbContext context)
        {
            _db = context;
        }

        //<<Read>>
        //Get: /comments
        public IActionResult Index()
        {
            var Comments = _db.Comments.ToList();
            ViewData["Comments"] = Comments;
            return View();
        }
        //<<Create>>
        //GET: /comments/create
        public IActionResult Create()
        {
            return View("Create");

        }

        [Authorize]
        //Post -/services/create
        [HttpPost]
        public IActionResult Create([Bind("message")] CommentsModel comment)
        {
            if (ModelState.IsValid) //validation check the state of the model
            {
                _db.Comments.Add(comment);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }



            return View(comment);
        }


        //GEt: /comments/edit/id
        public IActionResult Edit(int? id)
        {
            var Comment = _db.Comments.ToList().Find(c => c.Id == id);
            if (id == null || Comment == null)
            {
                return View("_NotFound");
            }
            ViewData["Comment"] = Comment;
            return View();
        }

        //Post: /comments/edit/id
        [HttpPost]




        public IActionResult Edit(int id, [Bind("message")] CommentsModel comment)
        {
            var Comment = _db.Comments.ToList().Find(c => c.Id == id);
            // update new vals
        


            _db.Comments.Update(Comment);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }

        [Authorize]

        //POST - /services/delete/id
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var comment = _db.Comments.ToList().FirstOrDefault(s => s.Id == id);


            _db.Comments.Remove(comment);
            _db.SaveChanges();
            return RedirectToAction("Index");


        }



    }
}
*/


using HealthChoice_Final_crud_auth.Data;
using HealthChoice_Final_crud_auth.Models;

namespace HealthChoice_Final_crud_auth.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public CommentsController(ApplicationDbContext context)
        {
            _db = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("ServiceId", "Content", "Date")] CommentsModel comment, int id)
        {
            if (ModelState.IsValid)
            {
                comment.Date = DateTime.Now;
                comment.ServiceId = id;
                _db.Add(comment);
                _db.SaveChanges();
                return Redirect("~/Services/details/" + id);
            }
            return View();
        }
        public IActionResult Delete(int? id)
        {
            var comment = _db.Comments.ToList().Find(x => x.Id == id);
            if (id == null || comment == null)
            {
                return Redirect("~/Services/");
            }
            int servId = comment.ServiceId;
            _db.Remove(comment);
            _db.SaveChanges();
            return Redirect("~/Services/details/" + servId);
        }
    }
}