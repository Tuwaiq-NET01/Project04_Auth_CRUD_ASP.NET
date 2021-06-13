using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ejar.Models
{
	public class ImageModel
	{
		public int Id { get; set; }
		public string ImageUrl { get; set; }


		[ForeignKey("CarModel")]
		public int CarId { get; set; }
		public CarModel Car { get; set; }
	}
}
