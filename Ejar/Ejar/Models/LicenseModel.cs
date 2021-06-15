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
		public string IssuingDate { get; set; }
		public string ExpirationDate { get; set; }
		public string LicensePhoto { get; set; }

		[ForeignKey("AccountModel")]
		public int AccountId { get; set; }
		public AccountModel Account { get; set; }

	}
}
