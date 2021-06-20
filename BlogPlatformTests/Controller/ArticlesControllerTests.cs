using System;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatform.Controllers;
using BlogPlatform.Data;
using BlogPlatform.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace BlogPlatformTests.Controller
{
    public class ArticlesControllerTests
    {
        private readonly ArticlesController _articlesController;

        public ArticlesControllerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "BlogApp").Options;
            var context = new AppDbContext(options);
            context.Database.EnsureDeleted();
            _articlesController = new ArticlesController(context);
            Seed(context);
        }
        
        [Fact]
        public void Get_All_Articles()
        {
            var articles = _articlesController.GetArticles("").Result;
            Assert.Equal(5, articles.Value.Count());
        }

        [Fact]
        public async Task Get_Article_By_Id()
        {
            var article = await _articlesController.GetArticle(2);
            var result = article.Result as OkResult; 
            Assert.Equal(200, result?.StatusCode);
        }
        
        [Fact]
        public async Task Get_Article_By_Invalid_Id_Returns_NotFound()
        {
            var article = await _articlesController.GetArticle(99);
            var result = article.Result as NotFoundResult;
            Assert.Equal(404, result?.StatusCode);
        }

        private void Seed(AppDbContext context)
        {
            var articles = new[]
            {
                new Article() {ArticleId = 1, Title = "title 1", Body = "body 1"},
                new Article() {ArticleId = 2, Title = "title 2", Body = "body 2"},
                new Article() {ArticleId = 3, Title = "title 3", Body = "body 3"},
                new Article() {ArticleId = 4, Title = "title 4", Body = "body 4"},
                new Article() {ArticleId = 5, Title = "title 5", Body = "body 5"},
            };
            context.Articles.AddRange(articles);
            context.SaveChanges();
        }
    }
}