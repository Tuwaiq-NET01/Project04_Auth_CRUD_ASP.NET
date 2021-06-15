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
        [AllowAnonymous]
        public IActionResult Details(int? id)
        {
            try
            {
            string userid = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var user = _context.Users.FirstOrDefault(user => user.Id == userid);
                ViewData["id"] = user.Id;

            }
            catch (NullReferenceException)
            {
                ViewData["id"] = null;
            }

            if (id == null)
            {
                return NotFound();
            }




            var game = _context.Games.ToList().Find(m => m.Id == id);
            var challenges = _context.Challenges.Where(i => i.GameId == game.Id).ToList();

            if (game == null)
            {
                return NotFound();
            }

            ViewData["game"] = game;
            ViewData["challenges"] = challenges;
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
                return Content("NOT FOUND!");
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








        //GET: /games/edit/5
        [Authorize]
        public IActionResult Edit(int? id)
        {
            var game = _context.Games.ToList().Find(p => p.Id== id);
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
            dbgame.GameImage= game.GameImage;

            _context.Games.Update(dbgame);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }









        //POST: /products/delete/id  
        [Authorize]
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var game = _context.Games.ToList().FirstOrDefault(p => p.Id== id);

            if (id == null || game == null)
            {
                return NotFound();
            }


            _context.Games.Remove(game);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        public IActionResult Search(string txt)
        {
            var target = txt;
            var searchRes = _context.Games.Where(a => a.GameName.Contains(target)).ToList();
            ViewData["target"] = target;
            ViewData["games"] = searchRes;
            return View();
        }



    }
}
