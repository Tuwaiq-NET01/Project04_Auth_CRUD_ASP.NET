using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project04_Auth_CRUD_ASP.NET.Models
{
    public class ReservationJoin
    {
        public Guid Id { get; set; }

        [DataType(DataType.Date)]
        public DateTime Day { get; set; }
        public string Time { get; set; }
        public string Barber { get; set; }
    }
}
