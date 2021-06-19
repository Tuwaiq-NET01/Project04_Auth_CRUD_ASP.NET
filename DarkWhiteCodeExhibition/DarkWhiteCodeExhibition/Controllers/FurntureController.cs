using DarkWhiteCodeExhibition.Data;
using DarkWhiteCodeExhibition.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DarkWhiteCodeExhibition.Controllers
{
    public class FurntureController : Controller
    {
        private readonly ApplicationDbContext _db;
        public FurntureController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {
            var FurntureModel = _db.FurntureModel.ToList();

            ViewData["FurntureModel"] = FurntureModel;
            return View(FurntureModel);

          
        }
       

        // GET: ArtPieces

        // GET: ArtPieces/Details/5
        public IActionResult Details(int? id)
        {
            var Fur = _db.FurntureModel.ToList().Find(product => product.Id == id);
            if (id == null || Fur == null)
            {
                return View("_NotFound");
            }
            ViewData["FurntureModel"] = Fur;
            return View(Fur);


        }
        // GET: ArtPieces/Create
        [Authorize]

        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtPieces/Create
     
        [HttpPost]


        public IActionResult Create([Bind("Id,Type,Name,DesignerName,Price,Image")] FurntureModel FurntureModel)
        {
            if (ModelState.IsValid)
            {
                _db.FurntureModel.Add(FurntureModel);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(FurntureModel);
        }

        // GET: ArtPieces/Edit/5
        [Authorize]

        public IActionResult Edit(int? id)
        {
            var Furn = _db.FurntureModel.ToList().Find(p => p.Id == id);
            if (id == null || Furn == null)
            {
                return View("_NotFound");
            }
            ViewData["FurntureModel"] = Furn;
            return View();
        }


        // POST: ArtPieces/Edit/5
    
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id, Type, Name, DesignerName, Price, Image")] FurntureModel FurntureModel)
        {
            if (id != FurntureModel.Id)
            {
                return View("_NotFound");
            }

            if (ModelState.IsValid)
            {
                _db.FurntureModel.Update(FurntureModel);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(FurntureModel);
        }

        // GET: ArtPieces/Delete/5
        [Authorize]

        public IActionResult Delete(int? id)
        {

            var Furnt = _db.FurntureModel.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || Furnt == null)
            {
                return View("_NotFound");
            }
            _db.FurntureModel.Remove(Furnt);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

      
        }

    }
    
