using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamApplication.Models
{
    public class Questions
    {
        public long Id { get; set; }
        public string QuestText { get; set; }
        public long RightAnswerId { get; set; }
        //one to many (Answer)
        // one to many (Exam)
        public List<Answers> answers { get; set; }
        public List<Exam> Exams { get; set; }
    }
}
