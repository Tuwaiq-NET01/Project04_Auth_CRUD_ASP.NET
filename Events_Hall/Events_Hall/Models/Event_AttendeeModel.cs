using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Events_Hall.Models
{
    public class Event_AttendeeModel
    {

        public int Id { get; set; }
        public int AttendeeId { get; set; }

        public AttendeeModel Attendee { get; set; }

        public int EventId { get; set; }

        public EventModel Event { get; set; }
    }
}
