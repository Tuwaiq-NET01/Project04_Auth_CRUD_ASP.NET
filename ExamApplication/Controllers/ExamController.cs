using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using ExamApplication.Models;
using ExamApplication.Data;

namespace ExamApplication.Controllers
{
    public class ExamController : Controller
    {
        private readonly MyDbContext _db;

        public ExamController(MyDbContext context)
        {
            _db = context;
        }

        // GET: Exam
        public ActionResult Index()
        {
            List<Questions> questions = _db.Question.ToList();
            List<long> qIds = new List<long>();
            foreach (var quest in questions)
            {
                qIds.Add(quest.Id);
            }
            ViewBag.Questions = string.Join(",", qIds);
            ViewBag.NextQuestion = questions[0];
            ViewBag.RightAnswer = questions[0].RightAnswerId;
            ViewBag.Answers = _db.Answer.Where(x => x.QuestionsId == questions[0].Id).ToList();
            ViewBag.QuestionCounter = 0;
            ViewBag.isStartExam = false;
            ViewBag.isSummary = false;
            List<Exam> summary = new List<Exam>();
            ViewBag.Summary = JsonConvert.SerializeObject(summary);

            return View("Index");
        }

        [HttpPost]
        public ActionResult Index(IFormCollection collection)
        {
            if (collection["questions"].Count > 0 && collection["questions"] != "")
            {
                string[] qIds = collection["questions"].ToString().Split(',');
                var questions = _db.Question.Find(Convert.ToInt64(qIds[0]));

                qIds = qIds.Skip(1).ToArray();

                var summary = JsonConvert.DeserializeObject<List<Exam>>(collection["Summary"]);


                ViewBag.Questions = string.Join(",", qIds);
                ViewBag.NextQuestion = questions;
                ViewBag.RightAnswer = questions.RightAnswerId;
                ViewBag.Answers = _db.Answer.Where(x => x.QuestionsId == questions.Id).ToList();

                if (Convert.ToInt32(collection["counter"]) > 0)
                {
                    summary.Add(new Exam
                    {
                        id = collection["counter"].ToString(),
                        qText = collection["QuestText"].ToString(),
                        rightAnswer = _db.Answer.Find(Convert.ToInt64(collection["RightAnswer"].ToString())).AnsText,
                        yourAns = (collection.Keys.Contains("radioAnswer")) ? _db.Answer.Find(Convert.ToInt64(collection["radioAnswer"].ToString())).AnsText : "",
                        result = (collection["RightAnswer"].ToString() == collection["radioAnswer"].ToString()) ? "right.png" : "wrong.png"
                    });
                }

                ViewBag.QuestionCounter = Convert.ToInt32(collection["counter"]) + 1;


                ViewBag.Summary = JsonConvert.SerializeObject(summary);

                ViewBag.isStartExam = true;
                ViewBag.isSummary = false;
            }
            else
            {
                var summary = JsonConvert.DeserializeObject<List<Exam>>(collection["Summary"]);
                summary.Add(new Exam
                {
                    id = collection["counter"].ToString(),
                    qText = collection["QuestText"].ToString(),
                    rightAnswer = _db.Answer.Find(Convert.ToInt64(collection["RightAnswer"].ToString())).AnsText,
                    yourAns = (collection.Keys.Contains("radioAnswer")) ? _db.Answer.Find(Convert.ToInt64(collection["radioAnswer"].ToString())).AnsText : "",
                    result = (collection["RightAnswer"].ToString() == collection["radioAnswer"].ToString()) ? "right.png" : "wrong.png"
                });

                ViewBag.Summary = summary;
                ViewBag.TotalCorrect = summary.Where(x => x.result == "right.png").ToList().Count;
                ViewBag.TotalQuestions = summary.Count;
                ViewBag.isStartExam = true;
                ViewBag.isSummary = true;
            }
            return View();
        }
    }
}