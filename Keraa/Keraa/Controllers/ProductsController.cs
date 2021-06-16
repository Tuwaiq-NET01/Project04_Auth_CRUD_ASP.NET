using Keraa.Data;
using Keraa.Models;
using Microsoft.AspNetCore.Identity; // for:_userManager
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Keraa.Controllers
{
    public class ProductsController : Controller
    {

        private readonly ApplicationDbContext _db;
        private readonly UserManager<ApplicationUser> _userManager;

        public ProductsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _db = context;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            ViewData["products"] = _db.Products.ToList();
            return View();
        }

        // GET: /products/id
        public IActionResult Details(int? id)
        {
            var Product = _db.Products.ToList().Find(product => product.Id == id);
            if (id == null || Product == null)
            {
                return View("_NotFound");
            }
            ViewData["Product"] = Product;
            return View(Product);

        }

        //GET - /products/create
        public IActionResult Create()
        {
            return View();
        }

        //POST - /proudcts/create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name", "ShortDesc", "CoverImage", "Catagory")] ProductModel product)
        {
            //Utilities u = new Utilities(Configuration);
            if (ModelState.IsValid) //check the state of model
            {
                var user = await _userManager.GetUserAsync(User);
               /* List<string> Coordinate = await Utilities.GetCurrentCoordinates();
                product.LocationLat = Coordinate[0];
                product.LocationLng = Coordinate[1];*/
               product.OwnerId = user.Id;
                _db.Products.Add(product);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }


        //GEt - /products/edit/id
        public IActionResult Edit(int? id)
        {
            var Product = _db.Products.ToList().Find(p => p.Id == id);
            if (id == null || Product == null)
            {
                return View("_NotFound");
            }
            ViewData["Product"] = Product;
            return View();
        }

        //POST - /products/edit/id
        [HttpPost]
        public async Task<IActionResult> Edit([Bind("Id", "Name", "ShortDesc", "CoverImage")] ProductModel prod)
        {
            /*
             --  This implementation is a security best practice to prevent overposting when updating a record of Products.
             --  TryUpdateModel used to update fields in the retrieved entity based on user input in the posted form data.
             -- As a best practice to prevent overposting, the fields that you want to be updateable by the Edit page
             are declared in the TryUpdateModel parameters. (The empty string preceding the list of fields in
             the parameter list is for a prefix to use with the form fields names.) Currently there are no 
             extra fields that you're protecting, but listing the fields that you want the model binder to bind
             ensures that if you add fields to the data model in the future, they're automatically protected
             until you explicitly add them here. 
            Resource: https://docs.microsoft.com/en-us/aspnet/core/data/ef-mvc/crud?view=aspnetcore-5.0#security-note-about-overposting
             */

            var productToUpdate = await _db.Products.FirstOrDefaultAsync(s => s.Id == prod.Id);
            if (await TryUpdateModelAsync<ProductModel>(
                productToUpdate,
                "",
                s => s.Name, s => s.ShortDesc, s => s.Catagory, s => s.CoverImage))
            {
                try
                {
                    await _db.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /* ex */)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator. And can Find me at GitHub: @1Riyad");
                }
            }


/*
        public async Task<IActionResult> Edit([Bind("Id", "Name", "ShortDesc", "CoverImage")] ProductModel prod)
        {*/
                _db.Products.Update(prod);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }


        // POST - /products/delete/id
        [HttpPost]
        public IActionResult Delete(int? id)
        {
            var Product = _db.Products.ToList().FirstOrDefault(p => p.Id == id);
            if (id == null || Product == null)
            {
                return View("_NotFound");
            }
            _db.Products.Remove(Product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



        // GET: /products/id
        public async Task<IActionResult> MyHub()
        {
            var user = await _userManager.GetUserAsync(User);

            var Product = _db.Products.Where(product => product.OwnerId == user.Id).ToList();
            if (user.Id == null || Product == null)
            {
                return View("_NotFound");
            }
            ViewData["products"] = Product;
            return View("Index", Product);

        }



    }
}
