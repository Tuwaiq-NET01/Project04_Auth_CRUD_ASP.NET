using AppStore.Controllers;
using AppStore.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NUnit.Framework;

namespace AppStoreTest.Controllers
{
    public class CategoriesControllerTest
    {
        private CategoriesController _categoriesController;
        private ApplicationDbContext _context;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "AppStore").Options;
            _context = new ApplicationDbContext(options);
            _context.Database.EnsureDeleted();
            _categoriesController = new CategoriesController(_context);
        }
        
        [Test]
        public void Type_Real_General_Category_String_in_URL_To_General_Category_Route_Return_View_Result()
        {
            CategoriesController categoriesController = new CategoriesController(_context);

            var result = categoriesController.GeneralCategory("Social Media");
            
            Assert.IsTrue(result is ViewResult);
        }

        [Test]
        public void Type_Fake_General_Category_String_in_URL_To_General_Category_Route_Return_View_Result_NotFoundPage()
        {
            CategoriesController categoriesController = new CategoriesController(_context);

            var result = categoriesController.GeneralCategory("Fake Category");
            
            Assert.IsTrue(result is ViewResult);
        }
        [Test]
        public void Type_Empty_String_in_URL_To_General_Category_Route_Return_View_Result_NotFoundPage()
        {
            CategoriesController categoriesController = new CategoriesController(_context);

            var result = categoriesController.GeneralCategory("");

            Assert.IsTrue(result is ViewResult);
        }

        [Test]
        public void Type_Number_in_URL_To_General_Category_Route_Return_View_Result_NotFoundPage()
        {
            CategoriesController categoriesController = new CategoriesController(_context);

            var result = categoriesController.GeneralCategory("12");

            Assert.IsTrue(result is ViewResult);
        }
    }
}