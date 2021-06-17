using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejar.Models
{
	public class AccountModel
	{
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public int PhoneNumber { get; set; }
		public string PersonalPhoto { get; set; }
		public string Address { get; set; }
		public decimal balance { get; set; }

		public string AccountComplete { get; set; }
		public LicenseModel License { get; set; }

		
		[ForeignKey("ApplicationUser")]
		public int UserId { get; set; }
		public ApplicationUser ApplicationUser { get; set; }
	}
}
