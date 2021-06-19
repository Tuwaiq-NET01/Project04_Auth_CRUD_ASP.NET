
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using DarkWhiteCodeExhibition.Models;
using Microsoft.AspNetCore.Identity;

namespace DarkWhiteCodeExhibition.Data
{
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<ArtPiecesModel> ArtPieces { get; set; }

    }
}