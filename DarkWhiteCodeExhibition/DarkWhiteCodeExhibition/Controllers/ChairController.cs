using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DarkWhiteCodeExhibition.Data;
using DarkWhiteCodeExhibition.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace DarkWhiteCodeExhibition.Controllers
{
    public class ChairController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ChairController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {

            var ChairModel = _db.ChairModel.ToList();
            ViewData["ChairModel"] = ChairModel;
            return View(ChairModel);

        
        }
     
        // GET: ArtPieces

        // GET: ArtPieces/Details/5
        public IActionResult Details(int? id)
        {
            var Chair = _db.ChairModel.ToList().Find(product => product.Id == id);
            if (id == null || Chair == null)
            {
                return View("_NotFound");
            }
            ViewData["ChairModel"] = Chair;
            return View(Chair);


        }
        // GET: ArtPieces/Create
        [Authorize]

        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtPieces/Create
      
        [HttpPost]


        public IActionResult Create([Bind("Id,Name,DesignerName,Price,Image")] ChairModel ChairModel)
        {
            if (ModelState.IsValid)
            {
                _db.ChairModel.Add(ChairModel);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(ChairModel);
        }

        // GET: ArtPieces/Edit/5
        [Authorize]

        public IActionResult Edit(int? id)
        {
            var Chair = _db.ChairModel.ToList().Find(p => p.Id == id);
            if (id == null || Chair == null)
            {
                return View("_NotFound");
            }
            ViewData["ChairModel"] = Chair;
            return View();
        }


        // POST: ArtPieces/Edit/5
       
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,DesignerName,Price,Image")] ChairModel ChairModel)
        {
            if (id != ChairModel.Id)
            {
                return View("_NotFound");
            }

            if (ModelState.IsValid)
            {
                _db.ChairModel.Update(ChairModel);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(ChairModel);
        }

        // GET: ArtPieces/Delete/5
        [Authorize]

        public IActionResult Delete(int? id)
        {

            var Art = _db.ChairModel.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || Art == null)
            {
                return View("_NotFound");
            }
            _db.ChairModel.Remove(Art);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

    
    }
}
