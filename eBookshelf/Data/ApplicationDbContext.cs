using System;
using System.Collections.Generic;
using System.Text;
using eBookshelf.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace eBookshelf.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ApplicationUser> Users { get; set; }

        public DbSet<EbookModel> eBooks { get; set; }

        public DbSet<NotesModel> Notes { get; set; }

        public DbSet<eBookshelf.Models.ConverterModel> ConverterModel { get; set; }

    }
}
