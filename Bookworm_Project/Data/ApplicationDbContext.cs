using Bookworm_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bookworm_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
     
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Create tables
        public DbSet<BookModel> Books { get; set; }
        public DbSet<AuthorModel> Authors { get; set; } 
        public DbSet<ReviewModel> Reviews { get; set; }
    }
}
