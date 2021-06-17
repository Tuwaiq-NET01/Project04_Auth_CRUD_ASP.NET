using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApplication.Models
{
    public class Answers
    {
        public long Id { get; set; }
        public string AnsText { get; set; }
        public bool isActive { get; set; }
        public long QuestionsId { get; set; }
        public Questions questions { get; set; }
    }
}
