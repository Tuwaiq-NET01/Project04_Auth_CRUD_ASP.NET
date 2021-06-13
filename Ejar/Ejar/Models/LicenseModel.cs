using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejar.Models
{
	public class LicenseModel
	{
		public int Id { get; set; }
		public int LicenseNumber { get; set; }
		public DateTime IssuingDate { get; set; }
		public DateTime ExpirationDate { get; set; }
		public string LicensePhoto { get; set; }

		[ForeignKey("ApplicationUser")]
		public int UserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }

	}
}
