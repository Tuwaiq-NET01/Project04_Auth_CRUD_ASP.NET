using BlogPlatform.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
    }
}