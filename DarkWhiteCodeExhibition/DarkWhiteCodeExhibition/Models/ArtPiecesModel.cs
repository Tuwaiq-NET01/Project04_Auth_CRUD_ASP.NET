using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using DarkWhiteCodeExhibition.Data;
using Microsoft.AspNetCore.Identity;

namespace DarkWhiteCodeExhibition.Models
{
    public class ArtPiecesModel 
    {
        [Key][Required]
        public int Id { get; set; }
        [Required]
        public string ArtName { get; set; }
        [Required]
        public string DesignerName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }
        public string ApplicationUserID { get; set; }
        [ForeignKey("ApplicationUserID")]
        public IdentityUser Users   { get; set; }
    }



}
