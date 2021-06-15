using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Keraa.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Catagory  { get; set; }
        public string Name { get; set; }
        public string ShortDesc { get; set; }
        public string CoverImage { get; set; }
        public bool IsRented { get; set; }
        //public List<ImegeModel> ProductImeges { get; set; }

        public string LocationLat { get; set; } // Latitude
        public string LocationLng { get; set; } //Longitude

        [ForeignKey("OwnerId")]
        public string OwnerId { get; set; }
        public UserProfileModel Owner { get; set; }


        [ForeignKey("TenantId")]
        public string TenantId { get; set; }
        public UserProfileModel Tenant { get; set; }

    }
}
