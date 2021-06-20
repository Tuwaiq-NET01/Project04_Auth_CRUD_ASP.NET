using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Musicify.Models
{
    public class PlayListSongModel
    {
        public int Id { get; set; }

        public int SongId { get; set; }
        [ForeignKey("SongId")]
        public SongModel Song { get; set; }

        public int PlayListId { get; set; }
        [ForeignKey("PlayListId")]
        public PlayListModel PlayList { get; set; }
    }
}
