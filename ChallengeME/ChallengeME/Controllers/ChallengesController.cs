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

            if (challenge == null)
            {
                return NotFound();
            }

            ViewData["challenge"] = challenge;
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
                return RedirectToAction("Details", "games", new { id = 7 });
            }

            return View();

        }


    }
}
