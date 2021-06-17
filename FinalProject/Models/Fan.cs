using System;
using System.Collections.Generic;

namespace FinalProject.Models
{
    public class Fan
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String img { get; set; }
        public String country { get; set; }



        public List<CelebrityVideo> CelebrityVideo { get; set; }
        public List<FanReqeustCelebrity> FanReqeustCelebrities { get; set; }
       
    }
}
