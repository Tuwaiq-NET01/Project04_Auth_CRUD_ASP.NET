using Microsoft.AspNetCore.Identity;
using Musicify.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Musicify.Models
{
    public class FavoriteModel
    {
        public int Id { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }

        public int SongId { get; set; }
        [ForeignKey("SongId")]
        public SongModel Song { get; set; }
    }
}
