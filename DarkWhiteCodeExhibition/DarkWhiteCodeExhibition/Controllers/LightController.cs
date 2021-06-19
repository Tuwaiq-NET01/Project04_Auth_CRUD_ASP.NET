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
    public class LightController : Controller
    {

        private readonly ApplicationDbContext _db;
        public LightController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {

            var LightModel = _db.LightModel.ToList();
            ViewData["LightModel"] = LightModel;
            return View(LightModel);

          

        }
       
        public IActionResult Details(int? id)
        {
            var Light = _db.LightModel.ToList().Find(product => product.Id == id);
            if (id == null || Light == null)
            {
                return View("_NotFound");
            }
            ViewData["LightModel"] = Light;
            return View(Light);


        }
        // GET: ArtPieces/Create
        [Authorize]

        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtPieces/Create
    
        [HttpPost]


        public IActionResult Create([Bind("Id,Name,DesignerName,Price,Image")] LightModel LightModel)
        {
            if (ModelState.IsValid)
            {
                _db.LightModel.Add(LightModel);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(LightModel);
        }

        // GET: ArtPieces/Edit/5
        [Authorize]

        public IActionResult Edit(int? id)
        {
            var Light = _db.LightModel.ToList().Find(p => p.Id == id);
            if (id == null || Light == null)
            {
                return View("_NotFound");
            }
            ViewData["LightModel"] = Light;
            return View();
        }


        // POST: ArtPieces/Edit/5
     
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,DesignerName,Price,Image")] LightModel LightModel)
        {
            if (id != LightModel.Id)
            {
                return View("_NotFound");
            }

            if (ModelState.IsValid)
            {
                _db.LightModel.Update(LightModel);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(LightModel);
        }

        // GET: ArtPieces/Delete/5
        [Authorize]

        public IActionResult Delete(int? id)
        {

            var Light = _db.LightModel.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || Light == null)
            {
                return View("_NotFound");
            }
            _db.LightModel.Remove(Light);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

     
    }
}
