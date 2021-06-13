using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejar.Models
{
	public class CarModel
	{
		public int Id { get; set; }
		public string CarName { get; set; }
		public string Manufacturer { get; set; }
		public string Type { get; set; }
		public int Year { get; set; }
		public string PlateNumber { get; set; }
		public decimal DayPrice { get; set; }
		public decimal HourPrice { get; set; }
		public string Available { get; set; }

		
		[ForeignKey("ApplicationUser")]
		public int UserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
		public ICollection<TripModel> Trips { get; set; }
		public ICollection<ImageModel> Images { get; set; }


	}
}
