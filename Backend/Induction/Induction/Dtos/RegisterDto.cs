using System;
using System.ComponentModel.DataAnnotations;

namespace Induction.Dtos
{
    public class RegisterDto
    {
      
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [MinLength(8)]
        public string Password { get; set; }
    }
}
