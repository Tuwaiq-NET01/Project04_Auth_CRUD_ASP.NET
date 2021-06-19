using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DarkWhiteCodeExhibition.Models
{
    //<center> <img src="https://th.bing.com/th/id/Rc212eb1f8bedfe5ec29ad782ab74ee7c?rik=ZSe6VmJwxFKceQ&pid=ImgRaw" width="1700" height="490" alt="" /></center>
    public class FurntureModel
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required]
        public string Type { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string DesignerName { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Image { get; set; }


    }
}
