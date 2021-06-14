using FinalProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<ApplicationUser>()
            //    .HasMany(a => a.Drops)
            //    .WithOne(d => d.ApplicationUser)
            //    .HasForeignKey(d => d.ApplicationUserId);

            builder.Entity<Drop>()
                .HasOne(d => d.ApplicationUser);

            //..

            builder.Entity<DropTags>()
                .HasKey(dt => new { dt.DropId, dt.TagId });

            builder.Entity<DropTags>()
                .HasOne(cp => cp.Drop)
                .WithMany(c => c.DropTags)
                .HasForeignKey(cp => cp.DropId);

            builder.Entity<DropTags>()
                .HasOne(cp => cp.Tag)
                .WithMany(c => c.DropTags)
                .HasForeignKey(cp => cp.TagId);

            //..

            builder.Entity<FavoriteDrop>()
                .HasKey(dt => new { dt.DropId, dt.ApplicationUserId });

            builder.Entity<FavoriteDrop>()
                .HasOne(cp => cp.Drop)
                .WithMany(c => c.FavoriteDrops)
                .HasForeignKey(cp => cp.DropId);

            builder.Entity<FavoriteDrop>()
                .HasOne(cp => cp.ApplicationUser)
                .WithMany(c => c.FavoriteDrops)
                .HasForeignKey(cp => cp.ApplicationUserId);

            base.OnModelCreating(builder);
        }

        public DbSet<Drop> Drops { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<DropTags> DropTags { get; set; }
        public DbSet<FavoriteDrop> FavoriteDrops { get; set; }
    }
}