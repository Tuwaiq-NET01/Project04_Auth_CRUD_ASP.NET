using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogPlatform.Data;
using BlogPlatform.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ArticlesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Article>>> GetArticles(string search)
        {
            if (string.IsNullOrEmpty(search))
            {
                return await _context.Articles.ToListAsync();
            }

            return await _context.Articles.Where(a => a.Title.Contains(search)).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Article>> GetArticle(int id)
        {
            var article = await _context.Articles.Include(a => a.ArticleTags)
                .ThenInclude(t=>t.Tag)
                .FirstOrDefaultAsync(a => a.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            return article;
        }
        
        [HttpPost]
        public async Task<ActionResult<Article>> PostArticle(Article article)
        {
            //article.Author = new User();
            article.CreatedAt = DateTime.Now;
            
            _context.Articles.Add(article);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetArticle), new {id = article.ArticleId}, article);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult> PutArticle(int id, Article updateArticle)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            article.Title = string.IsNullOrEmpty(updateArticle.Title) ? article.Title : updateArticle.Title;
            article.Body = string.IsNullOrEmpty(updateArticle.Body) ? article.Body : updateArticle.Body;
            _context.Articles.Update(article);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteArticle(int id)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            _context.Articles.Remove(article);
            await _context.SaveChangesAsync();
            return NoContent();

        }
        
        // get tags for an article

        // add tag to article
        [HttpPost("{id}/tags")]
        public async Task<ActionResult<IEnumerable<Tag>>> AddArticleTag(int id, [FromBody] string tag)
        {
            var article = await _context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound();
            }

            if (!string.IsNullOrWhiteSpace(tag))
            {
                // TODO check if tag doesnt already exist
                var newTag = await _context.Tags.AddAsync(new Tag() {Name = tag});
                await _context.ArticleTags.AddAsync(new ArticleTag() {Article = article, Tag = newTag.Entity});
                await _context.SaveChangesAsync();
            }

            return CreatedAtAction(nameof(GetArticle), new {id = article.ArticleId}, article);
        }
        
        //remove tag from article
        [HttpDelete("{id}/tags/{tagId}")]
        public async Task<ActionResult<IEnumerable<Tag>>> DeleteArticleTag(int id, int tagId)
        {
            var article = await _context.Articles
                .Include(at => at.ArticleTags)
                .FirstOrDefaultAsync(a => a.ArticleId == id);
            if (article == null)
            {
                return NotFound();
            }

            var tag = article.ArticleTags.FirstOrDefault(t => t.TagId == tagId);
            article.ArticleTags.Remove(tag);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetArticle), new {id = article.ArticleId}, article);
        }
        
        
        
        
    }
}