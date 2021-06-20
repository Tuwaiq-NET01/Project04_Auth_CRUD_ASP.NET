using System.Collections.Generic;
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
    public class TagsControllerTests
    {
        private readonly TagsController _tagsController;

        public TagsControllerTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseInMemoryDatabase(databaseName: "BlogApp").Options;
            var context = new AppDbContext(options);
            context.Database.EnsureDeleted();
            _tagsController = new TagsController(context);
            Seed(context);
        }

        [Fact]
        public void Get_All_Tags()
        {
            var tags = _tagsController.GetTags("").Result;
            Assert.Equal(3, tags.Value.Count());
        }

        [Fact]
        public async Task Get_Tag_By_Id()
        {
            var tag = await _tagsController.GetTag(1);
            var expectedTag = new Tag() {TagId = 1, Name = "tag 1", ArticleTags = new List<ArticleTag>()};
            Assert.Equal(expectedTag, tag.Value);
        }

        [Fact]
        public async Task Get_Tag_By_Invalid_Id_Returns_NotFound()
        {
            var tag = await _tagsController.GetTag(99);
            var result = tag.Result as NotFoundResult;
            Assert.Equal(404, result?.StatusCode);
        }

        private void Seed(AppDbContext context)
        {
            var tags = new[]
            {
                new Tag() {TagId = 1, Name = "tag 1"},
                new Tag() {TagId = 2, Name = "tag 2"},
                new Tag() {TagId = 3, Name = "tag 3"},
            };
            context.Tags.AddRange(tags);
            context.SaveChanges();
        }
    }
}