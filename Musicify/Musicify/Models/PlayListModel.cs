using Microsoft.AspNetCore.Identity;
using Musicify.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Musicify.Models
{
    public class PlayListModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //public bool IsPrivate { get; set; }

        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser User { get; set; }


        //O2M Playlist 2 Song : PlayListSong
        public ICollection<PlayListSongModel> playListSongs { get; set; }
    }
}
