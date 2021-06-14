using ChallengeME.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChallengeME.Controllers
{
    public class CommentsController : Controller
    {


        private readonly ApplicationDbContext _context;

        public CommentsController(ApplicationDbContext context)
        {

            _context = context;
        }



        public IActionResult Index()
        {

            //var comments = _context.Comments.ToList();
            //ViewData["comments"] = comments;

            return View();
        }



    }
}
