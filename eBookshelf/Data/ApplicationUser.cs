using System;
using Microsoft.AspNetCore.Identity;
using eBookshelf.Models;
using System.Collections.Generic;

namespace eBookshelf.Data
{
    public class ApplicationUser : IdentityUser
    {
        List<EbookModel> books { get; set; }
    }
}
