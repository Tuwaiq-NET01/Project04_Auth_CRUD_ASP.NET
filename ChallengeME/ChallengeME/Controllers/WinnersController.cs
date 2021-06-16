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

            return View();
        }



        public IActionResult Create(int coid, int chid ,[Bind("Description")] Winner winner)
        {

            winner.CommentId = coid; 
            winner.ChallengeId = chid;

            var comment = _context.Comments.ToList().Find(x => x.Id == coid);
            winner.Description = comment.Title;
            comment.isWinner = true;

            if (ModelState.IsValid)
            {
                _context.Winners.Add(winner);
                _context.SaveChanges();
                return RedirectToAction("details", "challenges", new { id = chid });
            }
            return View();
        }

    }
}
