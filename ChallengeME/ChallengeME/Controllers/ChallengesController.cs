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
    public class ChallengesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public ChallengesController(ApplicationDbContext context)
        {
            _context = context;
        }


        public IActionResult Index(int? id)
        {

            return View();
        }



        public IActionResult Details(int? id)
        {
            var challenge = _context.Challenges.ToList().Find(m => m.Id == id);
            var comments = _context.Comments.Where(x => x.ChallengeId == challenge.Id).ToList();
            var user = _context.Users.ToList();
            var games = _context.Games.ToList();

            //LINQ QUERY
            //var res = from cmt in _context.Comments
            //          join u in _context.Users
            //          on cmt.UserId equals u.Id
            //          select new 
            //          {
            //              CommentTitle = cmt.Title,
            //              CommentBody = cmt.Body,
            //              Username = u.UserName,
            //          };
            //var result = res.ToList();


            if (challenge == null)
            {
                return NotFound();
            }

            ViewData["challenge"] = challenge;
            ViewData["games"] = games;
            ViewData["comments"] = comments;
            return View();
        }


        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        //POST: /games/create
        [Authorize]
        [HttpPost]
        public IActionResult Create(int id , [Bind("Title", "Description", "Difficulty")] Challenge challenge)
        {

            challenge.GameId = id;
            if (ModelState.IsValid)
            {
                _context.Challenges.Add(challenge);
                _context.SaveChanges();
                return RedirectToAction("Details", "games", new { id = "same as the above if you figured it out..." });
            }

            return View();

        }


    }
}
