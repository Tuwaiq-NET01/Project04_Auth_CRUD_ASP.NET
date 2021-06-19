using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DarkWhiteCodeExhibition.Models;

namespace DarkWhiteCodeExhibition.Data
{

    public class ApplicationDbContext : IdentityDbContext


    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        public DbSet<ArtPiecesModel> ArtPiecesModel { get; set; }
        public DbSet<FurntureModel> FurntureModel { get; set; }
        public DbSet<ChairModel> ChairModel { get; set; }
        public DbSet<SofaModel> SofaModel { get; set; }
        public DbSet<TableModel> TableModel { get; set; }
        public DbSet<LightModel> LightModel { get; set; }

        public static implicit operator ApplicationDbContext(ApplicationUser v)
        {
            throw new NotImplementedException();
        }
    }
}
