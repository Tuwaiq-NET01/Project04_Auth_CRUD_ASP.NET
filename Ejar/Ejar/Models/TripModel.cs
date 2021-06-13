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
		public DateTime ReservedFrom { get; set; }
		public DateTime ReservedUntil { get; set; }
		public decimal TripPrice { get; set; }
		
		
		[ForeignKey("ApplicationUser")]
		public int UserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

		public CarModel Car { get; set; }

	}
}
