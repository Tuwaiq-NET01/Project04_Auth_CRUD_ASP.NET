using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejar.Models
{
	public class TripModel
	{
		public int Id { get; set; }
		public string DateReservedFrom { get; set; }
		public string TimeReservedFrom { get; set; }
		public string DateReservedUntil { get; set; }
		public string TimeReservedUntil { get; set; }
		public decimal TripPrice { get; set; }
		
		
		[ForeignKey("ApplicationUser")]
		public int UserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		//public int CarId { get; set; }
		public CarModel Car { get; set; }

	}
}
