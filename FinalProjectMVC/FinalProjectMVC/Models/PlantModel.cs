using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectMVC.Models
{
    public class PlantModel
    {
        [Key]
        public int PlantId { get; set; }
        public string PlantName { get; set; }
        public string PlantType { get; set; }
        public string PlantColor { get; set; }
        public double Price { get; set; }
        public int PlantHeight { get; set; }
        public string Image { get; set; }


        [ForeignKey("PlantStore")]
        public int StoreId { get; set; }//one to many relationship

        [ForeignKey("AspNetUsers")]
        public string Id { get; set; }//one to many 
    }
}
