using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace backend.Models
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string Name { get; set; }
        public string AccountType { get; set; }
        public uint CurrentQuota { get; set; }
        public uint TotalQuota { get; set; }
    }
}
