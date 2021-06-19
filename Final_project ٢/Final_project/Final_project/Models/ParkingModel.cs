using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Final_project.Models
{
    public class ParkingModel
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }

        //rel
        public int AdminId { get; set; }
        public AdminModel Admin { get; set; }
        public List<ReservationsModel> reservations { get; set; }

    }
}
