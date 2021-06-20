using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProject.Models
{
    public class Celebrity
    {
        public int id { get; set; }
        public String Name { get; set; }
        public String Email { get; set; }
        public String img { get; set; }
        public String country { get; set; }
        public String Description { get; set; }
        public String BriefDescription { get; set; }
        public String IntroductionVideo { get; set; }
        public int price { get; set; }

        public List<CelebrityVideo> CelebrityVideo { get; set; }

        public List<FanReqeustCelebrity> FanReqeustCelebrities { get; set; }
    }
}
