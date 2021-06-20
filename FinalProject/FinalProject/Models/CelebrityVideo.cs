using System;
namespace FinalProject.Models
{
    public class CelebrityVideo
    {
        public int id { get; set; }
        public String video { get; set; }

        public int CelebrityId { get; set; }
        public Celebrity celebrity { set; get; }

        public int FanId { get; set; }
        public Fan Fan { set; get; }


    }
}
