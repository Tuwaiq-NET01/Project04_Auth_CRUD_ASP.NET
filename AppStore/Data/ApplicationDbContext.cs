using System;
using System.Collections.Generic;
using System.Text;
using AppStore.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AppStore.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<AppModel> Apps { get; set; }
        
        public DbSet<CategoryModel> Categories { get; set; }
        
        public DbSet<DownloadModel> Downloads { get; set; }

         
    }
    
}