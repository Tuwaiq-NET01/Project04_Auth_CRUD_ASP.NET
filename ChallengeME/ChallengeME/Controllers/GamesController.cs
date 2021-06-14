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
    public class GamesController : Controller
    {

        private readonly ApplicationDbContext _context;

        public GamesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var games = _context.Games.ToList();
            ViewData["games"] = games;

            return View();
        }


        // GET: games/details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }


            var game = _context.Games.ToList().Find(m => m.Id == id);

            if (game == null)
            {
                return NotFound();
            }
            ViewData["game"] = game;
            return View();
        }

        //GET: /games/create 
        public IActionResult Create()
        {
            return View();
        }

        //POST: /games/create
        [Authorize]
        [HttpPost]
        public IActionResult Create([Bind("GameName","GameImage")] Game game)
        {
            string id = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(user => user.Id == id);
            // this proves that NameIdentifier stored inside User claims is the actual user id

            if (user == null)
            {
                return View("fof");
            }

            game.User_Id = user.Id;
            if (ModelState.IsValid)       //to chech the state of the model is correct.
            {
                _context.Games.Add(game);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(game);

        }




    }
}
