using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Events_Hall.Models
{
    public class EventModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        [Required]
        public string Time { get; set; }
        public string Duration { get; set; }
        public string Image { get; set; }

        public HallModel Hall { get; set; }

        public int HallId { get; set; }

        public PresentorModel Presentor { get; set; }

        public int PresentorId { get; set; }

        public string PresentorName{ get; set; }

        public List<Event_AttendeeModel> Event_Attendee { get; set; }


    }
}
