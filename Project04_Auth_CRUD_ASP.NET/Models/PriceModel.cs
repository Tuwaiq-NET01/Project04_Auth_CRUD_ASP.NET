using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project04_Auth_CRUD_ASP.NET.Models
{
    public class PriceModel
    {
        public Guid Id { get; set; }

        [Required]
        public decimal Value { get; set; }

        public BarberModel Barber { get; set; }
        public Guid BarberId { get; set; }

        public TimeModel Time { get; set; }
        public Guid TimeId { get; set; }
        public List<ReservationModel> Reservation { get; set; }

    }
}
