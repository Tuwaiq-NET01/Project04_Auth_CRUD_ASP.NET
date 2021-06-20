using System;
using System.Collections.Generic;

namespace RSDC_API
{
    public class Tournament
    {
        public int Id { get; set; }
        public string TourName { get; set; }
        public string Year { get; set; }
        public string TourType { get; set; }

        public int MemberId { get; set; }
         public Member Member { get; set; }

    }
}
