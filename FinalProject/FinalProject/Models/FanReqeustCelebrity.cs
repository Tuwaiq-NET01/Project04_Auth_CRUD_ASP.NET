using System;
namespace FinalProject.Models
{
    public class FanReqeustCelebrity
    {
        public int id { get; set; }
        public String From { get; set; }
        public String To { get; set; }
        public String RequstDec { get; set; }
        public bool AllowPubiling { get; set; }
        public String ReqeustState { get; set; }


        public int CelebrityId { get; set; }
        public Celebrity Celebrity { get; set; }

        public int FanId { get; set; }
        public Fan Fan { get; set; }
    }
}
