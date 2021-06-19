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
    public class SofaController : Controller
    {

        private readonly ApplicationDbContext _db;
        public SofaController(ApplicationDbContext context)
        {
            _db = context;
        }

        public IActionResult Index()
        {

            var SofaModel = _db.SofaModel.ToList();
            ViewData["SofaModel"] = SofaModel;
            return View(SofaModel);

           

        }
      
        // GET: ArtPieces

        // GET: ArtPieces/Details/5
        public IActionResult Details(int? id)
        {
            var Sofa = _db.SofaModel.ToList().Find(product => product.Id == id);
            if (id == null || Sofa == null)
            {
                return View("_NotFound");
            }
            ViewData["SofaModel"] = Sofa;
            return View(Sofa);


        }
        // GET: ArtPieces/Create
        [Authorize]

        public IActionResult Create()
        {
            return View();
        }

        // POST: ArtPieces/Create
     
        [HttpPost]


        public IActionResult Create([Bind("Id,Name,DesignerName,Price,Image")] SofaModel SofaModel)
        {
            if (ModelState.IsValid)
            {
                _db.SofaModel.Add(SofaModel);
                _db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(SofaModel);
        }

        // GET: ArtPieces/Edit/5
        [Authorize]

        public IActionResult Edit(int? id)
        {
            var Sofa = _db.SofaModel.ToList().Find(p => p.Id == id);
            if (id == null || Sofa == null)
            {
                return View("_NotFound");
            }
            ViewData["SofaModel"] = Sofa;
            return View();
        }


        // POST: ArtPieces/Edit/5
     
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Id,Name,DesignerName,Price,Image")] SofaModel SofaModel)
        {
            if (id != SofaModel.Id)
            {
                return View("_NotFound");
            }

            if (ModelState.IsValid)
            {
                _db.SofaModel.Update(SofaModel);
                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }
            return View(SofaModel);
        }

        // GET: ArtPieces/Delete/5
        [Authorize]

        public IActionResult Delete(int? id)
        {

            var Sofa = _db.SofaModel.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || Sofa == null)
            {
                return View("_NotFound");
            }
            _db.SofaModel.Remove(Sofa);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

      
    }
}
