using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Final.Models
{
    public class Publisher
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
