using Final_Project.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Final_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options){ }
        public DbSet<PlaceModel> Places { get; set; }
        public DbSet<LessorModel> Lessors { get; set; }
        public DbSet<RenterModel> Renters { get; set; }
        public DbSet<DesireModel> Desires { get; set; }

    }
}
