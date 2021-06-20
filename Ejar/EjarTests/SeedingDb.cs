using System.Collections.Generic;
using Ejar.Data;
using Ejar.Models;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;

namespace EjarTests
{
    public class SeedingDb
    {
        private ApplicationDbContext _db;

        public SeedingDb(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        [OneTimeSetUp]
        public void Setup()
        {
            // in memeory database
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: "Ejar")
                .Options;
            this._db = new ApplicationDbContext(options);
            var context = new ApplicationDbContext(options);

            // seed the database

        }
    }

}