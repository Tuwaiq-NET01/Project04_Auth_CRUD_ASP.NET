using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

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
    }
}