using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;

namespace BlogPlatform.Models
{
    public class Person : IdentityUser
    {
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public override string Email { get; set; }
        [Required(ErrorMessage = "Password is required")]
        [NotMapped]
        public string Password { get; set; }
        public string DisplayName { get; set; }
        public string Bio { get; set; }
        
        public string ImageUrl { get; set; }
        public DateTime DateJoined { get; set; }
        public List<Article> Articles { get; set; }
        public List<Comment> Comments { get; set; }


        #region overrides

        [JsonIgnore] public override bool EmailConfirmed { get; set; }

        [JsonIgnore] public override bool TwoFactorEnabled { get; set; }

        [JsonIgnore] public override string PhoneNumber { get; set; }

        [JsonIgnore] public override bool PhoneNumberConfirmed { get; set; }

        [JsonIgnore] public override string PasswordHash { get; set; }

        [JsonIgnore] public override string SecurityStamp { get; set; }

        [JsonIgnore] public override bool LockoutEnabled { get; set; }

        [JsonIgnore] public override int AccessFailedCount { get; set; }

        #endregion
    }
}