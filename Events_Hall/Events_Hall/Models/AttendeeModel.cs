using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Events_Hall.Models
{
    public class AttendeeModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Email { get; set; }
        [Required]
        public int Phone { get; set; }
        public string Field { get; set; }

        public List<Event_AttendeeModel> Event_Attendee { get; set; }

        public int EventId { get; set; }
    }
}
