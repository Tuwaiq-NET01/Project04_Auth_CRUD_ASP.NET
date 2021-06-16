using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace School.Models
{
    public class Room
    {
        public int RoomId { get; set; }
        [Required]
        [Display(Name = "Room Size")]
        public string RoomSize { get; set; }

        public int? StudentId { get; set; }

        public Student Student { get; set; }
    }
}
