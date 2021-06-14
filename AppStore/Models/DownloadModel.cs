using System;
using System.ComponentModel.DataAnnotations;
using AppStore.Data;
using Microsoft.AspNetCore.Identity;

namespace AppStore.Models
{
    public class DownloadModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime DownloadDate { get; set; }
        
        public AppModel App { get; set; }
        public int AppId { get; set; }
        
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
        
    }
}