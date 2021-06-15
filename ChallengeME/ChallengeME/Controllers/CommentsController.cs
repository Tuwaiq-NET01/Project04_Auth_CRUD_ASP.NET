using ChallengeME.Data;
using ChallengeME.Models;
using Microsoft.AspNetCore.Authorization;
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



        public IActionResult Index()
        {

            //var comments = _context.Comments.ToList();
            //ViewData["comments"] = comments;

            return View();
        }

        [HttpPost]
        [Authorize]
        public IActionResult Create(int id, [Bind("Title")] Comment comment)
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
            if (ModelState.IsValid)       //to chech the state of the model is correct.
            {
                _context.Comments.Add(comment);
                _context.SaveChanges();
                return RedirectToAction("Details", "challenges", new { id = id });
            }

            return View();
        }





    }
}
