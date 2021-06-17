using Ejar.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ejar.Data
{
	public class ApplicationDbContext : IdentityDbContext<ApplicationUser, IdentityRole<int>, int>
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
			: base(options)
		{

		}


		//db references
		public DbSet<CarModel> Car { get; set; }
		public DbSet<ImageModel> Image { get; set; }
		public DbSet<AccountModel> Account { get; set; }
		public DbSet<ApplicationUser> User { get; set; }
		public DbSet<LicenseModel> License { get; set; }
		public DbSet<Location> Location { get; set; }
		public DbSet<TripModel> Trip { get; set; }



	}
}
