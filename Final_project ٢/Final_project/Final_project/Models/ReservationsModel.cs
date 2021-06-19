using Final_project.Data;
using Final_project.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models
{
    public class ReservationsModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        //rel

        public string IDUser { get; set; }
        [ForeignKey("IDUser")]
        public IdentityUser User { get; set; }

        public int ParkingId { get; set; }
        public ParkingModel Parking { get; set; }
    }
}
