using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace _Platform_.Models
{
    public class Charity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Key]
        public int Id { get; set; }
        public string CharityName { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public IdentityUser Users { get; set; }
        public List<News> News { get; set; }
        public List<ambassador> ambassador { get; set; }
    }
}
