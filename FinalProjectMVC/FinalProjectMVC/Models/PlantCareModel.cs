using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectMVC.Models
{
    public class PlantCareModel
    {
        [Key]
        public int PlantCareId { get; set; }
        public string light { get; set; }
        public double temperature { get; set; }
        public string irrigation { get; set; }

        [ForeignKey("PlantModel")]
        public int plantId { get; set; }

    }
}
