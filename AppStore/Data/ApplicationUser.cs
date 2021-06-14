using System.Collections.Generic;
using AppStore.Models;
using Microsoft.AspNetCore.Identity;

namespace AppStore.Data
{
    public class ApplicationUser : IdentityUser
    {
        public List<DownloadModel> Downloads { get; set; }
        public List<RatingModel> Ratings { get; set; }
    }
}