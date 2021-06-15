using System;
using System.Collections.Generic;
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

        //public string OwnerUserProfileId { get; set; }
        public UserProfileModel Owner { get; set; }

        //public string TenantUserProfileId { get; set; }
        public UserProfileModel Tenant { get; set; }
    }
}
