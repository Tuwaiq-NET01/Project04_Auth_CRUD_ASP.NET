using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChoice_Final_crud_auth.Models
{
    public class EventsModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public DateTime Date { get; set; }

        public string Overview { get; set; }
        public string Image { get; set; }

        public string Location { get; set; }

        //Relationship Many-to-Many

        public ICollection<FavoriteModel> Favorites { get; set; }


    }
}
