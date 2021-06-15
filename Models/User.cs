using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Final.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public string Address { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool Admin { get; set; }
        public virtual ICollection<Book> Books { get; set; }


    }
}
