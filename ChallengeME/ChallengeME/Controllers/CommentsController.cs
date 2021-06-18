using ChallengeME.Data;
using ChallengeME.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;


namespace ChallengeME.Controllers
{
    public class CommentsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public JsonResult getComments()
        {
            var comments = _context.Comments.ToList();

            return Json(comments);
        }

        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(int id, [Bind("Title", "Body")] Comment comment)
        {
            string iduser = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(user => user.Id == iduser);
            // this proves that NameIdentifier stored inside User claims is the actual user id

            if (user == null)
            {
                return Content("NOT FOUND!");
            }
            comment.ChallengeId = id;
            comment.UserId = user.Id;
            comment.Time = DateTime.Now;
            if (ModelState.IsValid)       //to chech the state of the model is correct.
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return RedirectToAction("details", "challenges", new { id = id });
            }

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var comment = _context.Comments.ToList().FirstOrDefault(p => p.Id == id);

            if (id == null || comment == null)
            {
                return NotFound();
            }

            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return RedirectToAction("details", "challenges", new { id = comment.ChallengeId });
        }





        //////////////////////////////////////////
        /////////////////////////////////////tests
        //////////////////////////////////////////

        public Comment DeleteTest(int? id)
        {
            var comment = _context.Comments.ToList().FirstOrDefault(p => p.Id == id);


            _context.Comments.Remove(comment);
            _context.SaveChanges();
            return comment;
        }
    }
}