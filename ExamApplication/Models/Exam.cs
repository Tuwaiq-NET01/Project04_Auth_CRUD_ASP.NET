using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApplication.Models
{
    public class Exam
    {
        public string id { get; set; }
        public string qText { get; set; }
        public string yourAns { get; set; }
        public string rightAnswer { get; set; }
        public string result { get; set; }
        public long QuestionsId { get; set; }
        public Questions questions { get; set; }
        public long AdminsId { get; set; }
        public Admins Admin { get; set; }
    }
}
