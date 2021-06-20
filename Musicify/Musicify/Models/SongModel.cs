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

        [ForeignKey("SingerId")]
        public int SingerId { get; set; }
        public SingerModel Singer { get; set; }

        // M2M
        public ICollection<FavoriteModel> Favorites { get; set; }

        //O2M Playlist 2 Song : PlayListSong
        public ICollection<PlayListSongModel> playListSongs { get; set; }
       
    }
}
