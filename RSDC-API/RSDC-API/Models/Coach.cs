using System;
using System.Collections.Generic;

namespace RSDC_API
{
    public class Coach
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public DateTime StartDate { get; set; }
        public char Gender { get; set; }
        public string Image { get; set; }
        
        public ICollection<Member> Members { get; set; }

    }
}
