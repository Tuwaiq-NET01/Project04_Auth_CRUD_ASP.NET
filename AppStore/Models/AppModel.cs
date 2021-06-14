using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AppStore.Models
{
    public class AppModel
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Description { get; set; }
        public string GeneralCategory { get; set; }
        public float AverageRating { get; set; }
        public string Size { get; set; }
        public int DownloadsCount { get; set; }
        
        public List<DownloadModel> Downloads { get; set; }
        
    }
}