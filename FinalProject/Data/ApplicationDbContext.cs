using FinalProject.Models;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using FinalProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Data
{
    
    public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
    {
        public DbSet<Celebrity> celebrities { get; set; }
        public DbSet<CelebrityVideo> CelebrityVideo { get; set; }
        public DbSet<Fan> fans { get; set; }
        public DbSet<FanReqeustCelebrity> fanReqeustCelebrities { get; set; }



        public ApplicationDbContext(
            DbContextOptions options,
            IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
        {
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<FanReqeustCelebrity>()
                .HasOne(f => f.Fan)
                .WithMany(fc => fc.FanReqeustCelebrities)
                .HasForeignKey(fi => fi.FanId);

            modelBuilder.Entity<FanReqeustCelebrity>()
                .HasOne(c => c.Celebrity)
                .WithMany(fc => fc.FanReqeustCelebrities)
                .HasForeignKey(ci => ci.CelebrityId);


        }
    }
}
