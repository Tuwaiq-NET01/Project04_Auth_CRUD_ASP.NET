using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musicify.Data;
using Musicify.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Musicify.Controllers
{
    [Authorize]
    public class PlayListsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;

        public PlayListsController(ApplicationDbContext db, UserManager<IdentityUser> userManager)
        {
            _db = db;
            _userManager = userManager;
        }

        /*// if you want to do test unComment from constrakter 
        // for test
        public PlayListsController(ApplicationDbContext db)
        {
            _db = db;          
        }*/

        public IActionResult Index()
        {
            var userId = _userManager.GetUserId(User);
            var PlayLists = _db.PlayLists.Where(pl => pl.UserId == userId).ToList();
            ViewData["PlayLists"] = PlayLists;
            return View();
        }

        // GET: /PlayLists/id
        public IActionResult Details(int? id)
        {
            var PlayLists = _db.PlayLists.First(PL => PL.Id == id);
            var PLSongs = _db.playListSongs.Where(pls => pls.PlayListId == PlayLists.Id)
                .Include(p => p.Song).ToList(); 
            if (id == null || PlayLists == null)
            {
                return View("_NotFound");
            }
            var Songs = new List<SongModel> { };
            foreach(var pls in PLSongs)
            {
                Songs.Add(pls.Song);
            }
            ViewData["PlayLists"] = PlayLists;
            ViewData["Songs"] = Songs;
            return View(PlayLists);

        }

        // Create

        // GET: /PlayLists/create
        [HttpGet]
        public IActionResult Create()
        {

            return View();

        }

        // Post: /PlayLists/create
        [HttpPost]
        public IActionResult Create([Bind("Name")] PlayListModel PlayList)
        {
            // if for validations
            if (ModelState.IsValid)
            {
                PlayList.UserId = _userManager.GetUserId(User);
                _db.PlayLists.Add(PlayList);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(PlayList);
        }

        // POST: /PlayLists/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var PlayLists = _db.PlayLists.First(p => p.Id == id);
            var PLS = _db.playListSongs.Where(pls => pls.PlayListId == PlayLists.Id).ToList();
            if (id == null || PlayLists == null)
            {
                return View("_NotFound");
            }
            foreach(var pls in PLS)
            {
                _db.playListSongs.Remove(pls);
            }
            _db.PlayLists.Remove(PlayLists);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // POST: /PlayLists/deleteSong/id
        [HttpPost]
        public IActionResult DeleteSong(int? id)
        {
            var Song = _db.Songs.First(p => p.Id == id);
            var PLS = _db.playListSongs.First(pls => pls.SongId == Song.Id);
            if (id == null || PLS == null)
            {
                return View("_NotFound");
            }
            
            _db.playListSongs.Remove(PLS);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        // method test
        public PlayListModel getPlayList(int id) {

            PlayListModel p = _db.PlayLists.FirstOrDefault(p => p.Id == id);
            if (p == null)
            {
                throw new NullReferenceException();
            }
            return p ;
        }
    }
}
