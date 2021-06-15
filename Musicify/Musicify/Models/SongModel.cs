using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Musicify.Models
{
    public class SongModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string URL { get; set; }

        public int  SingerId { get; set; }
        [ForeignKey("SingerId")]
        public SingerModel Singer { get; set; }

        public ICollection<FavoriteModel> Favorites { get; set; }

    }
}
