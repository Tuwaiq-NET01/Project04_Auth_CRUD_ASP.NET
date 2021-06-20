using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mininet.Models;

namespace mininet.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<RssFeedModel> rssFeeds {get; set;}
        public DbSet<NoteModel> notes {get; set;}
        public DbSet<ProfileModel> profiles {get;set;}
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
