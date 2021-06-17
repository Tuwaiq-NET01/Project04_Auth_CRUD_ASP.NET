using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Tchess.Data;
using Tchess.Models;

namespace Tchess.Controllers
{
    public class GameController : Controller
    {
        // GET
        private readonly ApplicationDbContext _db;

        public GameController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            ViewData["db"] = _db;
            ViewData["games"] = _db.Games.ToList();
            return View();
        }

        public IActionResult UserGames()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Profile profile = _db.Profiles.FirstOrDefault((profilee => profilee.UserId == userid));
            List<Game> games =
                _db.Games.Where((game => game.ProfileId == profile.Id)).ToList();
            ViewData["games"] = games;
            ViewData["db"] = _db;
            ViewData["name"] = profile.Name;
            return View();
        }

        public IActionResult Play()
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Profile profile = _db.Profiles.FirstOrDefault((profilee => profilee.UserId == userid));
            ViewData["profile"] = profile;
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Moves", "Winner", "NumMoves", "ProfileId")]
            Game game)
        {
            if (ModelState.IsValid)
            {
                _db.Games.Add(game);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("Index");
        }

        [HttpPost]
        public IActionResult Edit([Bind("Id", "Moves", "Winner", "NumMoves", "ProfileId")]
            Game game)
        {
            _db.Games.Update(game);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Delete(int? id)
        {
            _db.Remove(_db.Games.FirstOrDefault((game => game.Id == id)));
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult GetGame(int id)
        {
            return Json(_db.Games.FirstOrDefault((game => game.Id == id)));
        }

        public IActionResult Showgame(int id)
        {
            ViewData["game"] = _db.Games.FirstOrDefault(game => game.Id == id);
            return View();
        }

        public void LoseRating(int id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Profile profile = _db.Profiles.FirstOrDefault((profilee => profilee.UserId == userid));
            if (id == profile.Id)
            {
                profile.Rating -= 200;
                _db.Profiles.Update(profile);
                _db.SaveChanges();
            }
        }

        public void WinRating(int id)
        {
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            Profile profile = _db.Profiles.FirstOrDefault((profilee => profilee.UserId == userid));
            if (id == profile.Id)
            {
                profile.Rating += 200;
                _db.Profiles.Update(profile);
                _db.SaveChanges();
            }
        }

        public Game GetGameID(int id)
        {
            Game g = _db.Games.FirstOrDefault((game => game.Id == id));
            if (g == null)
            {
                throw new NullReferenceException();
            }
            return _db.Games.FirstOrDefault((game => game.Id == id));
        }
        public List<Game> GetAllGames()
        {
            List<Game> g = _db.Games.ToList();
            return g;
        }
        public void Edit_Game(Game game)
        {
            if (_db.Games.FirstOrDefault((game1 =>game1.Id == game.Id)) == null)
            {
                throw new NullReferenceException();

            }
            _db.Games.Update(game);
            _db.SaveChanges();
        }
        public void create_Game(Game game)
        {
            if (ModelState.IsValid)
            {
                _db.Games.Add(game);
                _db.SaveChanges();
            }
            else
            {
                throw new Exception();
            }
        }
        public void DeleteGame(int id)
        {
            Game game = _db.Games.FirstOrDefault((game => game.Id == id));
            if (game == null)
            {
                throw new NullReferenceException();
            }
            _db.Remove(game);
            _db.SaveChanges();
        }
    }
}