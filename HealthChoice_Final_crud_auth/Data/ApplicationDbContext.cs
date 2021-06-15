using HealthChoice_Final_crud_auth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthChoice_Final_crud_auth.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ServicesModel> Services { get; set; }
        public DbSet<MembershipsModel> MembberShips { get; set; }

        public DbSet<CommentsModel> Comments { get; set; }


    }
}
