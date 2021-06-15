using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Podcast_Website.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Podcast_Website.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProfileModel> Profiles { get; set; }

        public DbSet<PodcastModel> Podcasts { get; set; }
        public DbSet<PodcastProfileModel> PodcastProfile { get; set; }

        public DbSet<TagModel> Tags { get; set; }
        public DbSet<Prodcast_TagModel> Prodcast_Tag { get; set; }

        

    }
}
