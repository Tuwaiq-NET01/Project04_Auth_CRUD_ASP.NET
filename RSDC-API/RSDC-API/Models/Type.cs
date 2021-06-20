using System;
using System.Collections.Generic;

namespace RSDC_API
{
    public class Type
    {
        public int Id { get; set; }
        public int Fee { get; set; }
        public string DivingType { get; set; }

        public ICollection<Member> Members { get; set; }
        
        public ICollection<Store> Stores { get; set; }


    }
}
