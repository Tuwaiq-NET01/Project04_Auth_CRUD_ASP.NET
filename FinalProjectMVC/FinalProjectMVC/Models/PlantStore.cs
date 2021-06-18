using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectMVC.Models
{
    public class PlantStore
    {
        [Key]
        public int StoreId { get; set; }
        public string StoreName { get; set; }
        public string StoreLocation { get; set; }
        public string StorePhoneNo { get; set; }
        public string StoreEmail { get; set; }

        public List<PlantModel> plant { get; set; }

    }
}
