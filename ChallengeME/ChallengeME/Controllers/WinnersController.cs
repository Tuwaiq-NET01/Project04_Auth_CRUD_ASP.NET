using ChallengeME.Data;
using ChallengeME.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeME.Controllers
{
    public class WinnersController : Controller
    {

        private readonly ApplicationDbContext _context;

        public WinnersController(ApplicationDbContext context)
        {

            _context = context;
        }



        public IActionResult Index()
        {
            ViewData["users"] = _context.Users.ToList();
            ViewData["winners"] = _context.Winners.ToList();
            ViewData["comments"] = _context.Comments.ToList();

            return View("Index");
        }



        public IActionResult Create(int coId ,[Bind("Description")] Winner winner)
        {

            var dbcomment = _context.Comments.ToList().Find(x => x.Id == coId);
            winner.CommentId = coId;
            winner.Description = dbcomment.Title;
            winner.UserId = dbcomment.UserId;
            var dbuser = _context.Users.ToList().Find(x => x.Id == dbcomment.UserId);
            if (ModelState.IsValid)
            {
                dbcomment.isWinner = true;
                dbuser.Wins++;
                _context.Winners.Add(winner);
                _context.SaveChanges();
                return RedirectToAction("details", "challenges", new { id = dbcomment.ChallengeId});
            }
            return View();
        }

    }
}
