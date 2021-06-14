using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ejar.Models
{
	public class ApplicationUser :  IdentityUser<int>
	{
		
		public AccountModel Account { get; set; }
		public LicenseModel License { get; set; }
		public ICollection<CarModel> Cars { get; set; }
		public ICollection<TripModel> Trips { get; set; }
		public Location Location { get; set; }


	}
}
