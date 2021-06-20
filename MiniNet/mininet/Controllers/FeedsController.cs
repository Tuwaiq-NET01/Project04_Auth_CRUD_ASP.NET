using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mininet.Models;
using Microsoft.AspNetCore.Authorization;
using mininet.Data;
using Microsoft.AspNetCore.Identity;
using CodeHollow.FeedReader;

namespace mininet.Controllers
{
    [Authorize]
    public class FeedsController : Controller
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<AppUser> userManager;
        public FeedsController(
            ApplicationDbContext context,
            UserManager<AppUser> userMngr
            )
        {
            _db = context;
            userManager = userMngr;
        }
        public IActionResult Index()
        {
            var userId = userManager.GetUserId(User);
            var feeds = _db.rssFeeds.Where(u => u.UserId == userId).ToList();
            ViewData["feeds"] = feeds;
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind] RssFeedModel feed)
        {
            if (ModelState.IsValid)
            {
                var fetchRssInfo = await FeedReader.ReadAsync(feed.Url);
                if (fetchRssInfo != null)
                {
                    feed.Title = fetchRssInfo.Title;
                    feed.Description = fetchRssInfo.Description;
                    feed.Link = fetchRssInfo.Link;
                    feed.UserId = userManager.GetUserId(User);
                    _db.rssFeeds.Add(feed);
                    _db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(feed);
        }

        public async Task<IActionResult> Details([FromRoute] long Id)
        {
            var userId = userManager.GetUserId(User);
            var feed = _db.rssFeeds.FirstOrDefault(f => f.Id == Id && f.UserId == userId);
            var items = await GetItems(feed.Url);
            ViewData["feedItems"] = items;
            return View();
        }
        [HttpPost]
        public IActionResult Delete([FromRoute] long? Id)
        {
            var userId = userManager.GetUserId(User);
            var feed = _db.rssFeeds.FirstOrDefault(f => f.Id == Id && f.UserId == userId);
            if( feed == null || Id == null)
            {
                return View("_NotFound");
            }
            _db.rssFeeds.Remove(feed);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        private async Task<ICollection<RssItemDTO>> GetItems(string Url)
        {
            var feedReader = await FeedReader.ReadAsync(Url);
            var rssItemDTOs = new List<RssItemDTO>();
            foreach (var item in feedReader.Items)
            {
                var rssItemDTO = new RssItemDTO
                {
                    Title = (item.Title != null) ?
                            item.Title
                            : "",
                    Description = (item.Description != null) ?
                            item.Description
                            : "",
                    Link = (item.Link != null) ?
                            item.Link
                            : "",
                };
                rssItemDTOs.Add(rssItemDTO);
            }
            return rssItemDTOs;
        }
        [NonAction]
        public IActionResult DeleteTest(long? Id)
        {
            
            var feed = _db.rssFeeds.FirstOrDefault(f => f.Id == Id);
            if( feed == null || Id == null)
                return View("_NotFound");
            _db.rssFeeds.Remove(feed);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}