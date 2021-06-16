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
            var comments = _context.Comments.Where(x => x.ChallengeId == challenge.Id).OrderByDescending(x => x.Id).ToList();
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
        public IActionResult Create(int? id)
        {
            ViewData["game"] = _context.Games.ToList().Find(x => x.Id == id);
            ViewData["diff"] = getDiff();

            return View();
        }

        //POST: /games/create
        [Authorize]
        [HttpPost]
        public IActionResult Create(int id , string uid,[Bind("Title", "Description", "Difficulty")] Challenge challenge)
        {
            ViewData["game"] = _context.Games.ToList().Find(x => x.Id == id);
            ViewData["diff"] = getDiff();
            challenge.GameId = id;
            challenge.UserId = uid;
            if (ModelState.IsValid)
            {
                _context.Challenges.Add(challenge);
                _context.SaveChanges();
                return RedirectToAction("Details", "games", new { id = id });
            }
            else
            {
                return View();
            }

        }




        [Authorize]
        public IActionResult Edit(int? id)
        {
            var game = _context.Games.ToList().Find(p => p.Id == id);
            if (id == null || game == null)
            {
                return NotFound();
            }

            ViewData["game"] = game;

            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(int id, [Bind("GameName", "GameImage")] Game game)
        {

            var dbgame = _context.Games.ToList().Find(p => p.Id == id);
            dbgame.GameName = game.GameName;
            dbgame.GameImage = game.GameImage;

            _context.Games.Update(dbgame);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }









        [Authorize]
        [HttpPost]
        public IActionResult Delete(int? id)
        {

            var challenge = _context.Challenges.ToList().FirstOrDefault(p => p.Id == id);

            if (id == null || challenge == null)
            {
                return NotFound();
            }


            _context.Challenges.Remove(challenge);
            _context.SaveChanges();
            return RedirectToAction("details", "games", new { id = challenge.GameId });
        }





        public List<string> getDiff()
        {
            return new List<string>() { "Easy", "Normal", "Hard" };
        }


    }
}
