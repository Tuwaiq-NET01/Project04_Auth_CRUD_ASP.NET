using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GiftShopV1.Models
{
    public class CustomerModel
    {
        [Key]
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }

    }
}
