using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;
using AppStore.Models;
using Microsoft.AspNetCore.Identity;

namespace AppStore.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData] 
        public string Name { get; set; }
        [PersonalData] 
        [DataType(DataType.Url)]
        public string ProfilePic { get; set; }
        public List<DownloadModel> Downloads { get; set; }
        public List<RatingModel> Ratings { get; set; }
        
    }
}