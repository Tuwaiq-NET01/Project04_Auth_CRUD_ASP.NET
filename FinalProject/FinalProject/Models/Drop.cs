using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Drop
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public List<DropTags> DropTags { get; set; }
        public List<FavoriteDrop> FavoriteDrops { get; set; }
    }
}
