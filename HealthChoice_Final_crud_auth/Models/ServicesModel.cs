using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HealthChoice_Final_crud_auth.Models
{
    public class ServicesModel
    {
        [Key]
        public int Id { get; set; }
        public string servName { get; set; }
        public string servOverview { get; set; }
        public string servLogo { get; set; }

        public string servWebsite { get; set; }
        public string servLocation { get; set; }

        public string servType { get; set; }

   

        //Relationship One-to-Many
        public List<CommentsModel>Comments { get; set; }



    }
}




