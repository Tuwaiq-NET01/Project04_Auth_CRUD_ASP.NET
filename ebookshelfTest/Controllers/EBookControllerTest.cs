using eBookshelf.Controllers;
using eBookshelf.Data;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ebookshelfTest.Controllers
{
    class EBookControllerTest
    {
        private EBookController eBookController;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _config;

        [SetUp]
        public void Setup()
        {
            eBookController = new EBookController(_config, _context);
        }

      

    }
}