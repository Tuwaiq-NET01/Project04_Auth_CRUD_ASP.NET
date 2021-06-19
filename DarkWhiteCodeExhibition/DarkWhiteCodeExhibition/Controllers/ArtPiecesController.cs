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
    public class ArtPiecesController : Controller
    {
        private readonly ApplicationDbContext _db;
        public ArtPiecesController(ApplicationDbContext context )
        {
            _db = context;
        }

      
        public IActionResult Index()
        {

            var ArtPiecesModel = _db.ArtPiecesModel.ToList();
            ViewData["ArtPiecesModel"] = ArtPiecesModel;
            return View(ArtPiecesModel);

          
        }
       

            // GET: ArtPieces
        
        // GET: ArtPieces/Details/5
        public IActionResult Details(int? id)
        {
            var Art = _db.ArtPiecesModel.ToList().Find(product => product.Id == id);
            if (id == null || Art == null)
            {
                return View("_NotFound");
            }
            ViewData["ArtPiecesModel"] = Art;
            return View(Art);


        }
        // GET: ArtPieces/Create
        [Authorize]

        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtPieces/Create
      
        [HttpPost]


        public IActionResult Create([Bind("Id,ArtName,DesignerName,Price,Image")] ArtPiecesModel artPiecesModel)
        {
            if (ModelState.IsValid)
            {
                _db.ArtPiecesModel.Add(artPiecesModel);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(artPiecesModel);
        }

        // GET: ArtPieces/Edit/5
        [Authorize]

        public IActionResult Edit(int? id)
        {
            var artP = _db.ArtPiecesModel.ToList().Find(p => p.Id == id);
            if (id == null || artP == null)
            {
                return View("_NotFound");
            }
            ViewData["ArtPiecesModel"] = artP;
            return View();
        }


        // POST: ArtPieces/Edit/5
       
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,ArtName,DesignerName,Price,Image")] ArtPiecesModel artPiecesModel)
        {
            if (id != artPiecesModel.Id)
            {
                return View("_NotFound");
            }

            if (ModelState.IsValid)
            {
                _db.ArtPiecesModel.Update(artPiecesModel);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(artPiecesModel);
        }

        // GET: ArtPieces/Delete/5
        [Authorize]

        public IActionResult Delete(int? id)
        {

            var Art = _db.ArtPiecesModel.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || Art == null)
            {
                return View("_NotFound");
            }
            _db.ArtPiecesModel.Remove(Art);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

       
    }
}
