﻿using System;
using System.ComponentModel.DataAnnotations;

namespace backend.Models.Authentication
{
    public class Register
    {
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
        public string AccountType { get; set; }
        public uint CurrentQuota { get; set; }
        public uint TotalQuota { get; set; }
    }
}
