using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ExamApplication.Data;
using ExamApplication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ExamApplication.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly MyDbContext _db;

        public QuestionsController(MyDbContext context)
        {
            _db = context;
        }

        
        public ActionResult Index()
        {
            return View(_db.Question.ToList());
        }
     


        public ActionResult Create()
        {
            return View();
        }

     

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Questions quest = new Questions();
                    quest.QuestText = collection["QuestText"].ToString();
                    _db.Add(quest);
                    _db.SaveChanges();
                    string[] answers = collection["answers"].ToString().TrimEnd('!').Split('!');

                    foreach (var ans in answers)
                    {
                        Answers answer = new Answers();
                        answer.AnsText = ans;
                        answer.QuestionsId = quest.Id;
                        answer.isActive = true;

                        _db.Add(answer);
                        _db.SaveChanges();

                        if (ans.Equals(collection["rightAnswer"].ToString()))
                        {
                            quest.RightAnswerId = answer.Id;
                            _db.Update(quest);
                            _db.SaveChanges();
                        }
                    }

                    return RedirectToAction("Index");
                }

                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        
        public ActionResult Edit(long id)
        {
            var question = _db.Question.Find(id);
            List<Answers> answers = _db.Answer.Where(x => x.QuestionsId == question.Id).ToList();
            ViewBag.answers = answers;
            return View(question);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, IFormCollection collection)
        {
            try
            {
                var question = _db.Question.Find(id);
                question.QuestText = collection["QuestText"].ToString();
                question.RightAnswerId = Convert.ToInt64(collection["answers"].ToString());
                _db.Update(question);
                _db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        
        public ActionResult Delete(long id)
        {
            var question = _db.Question.Find(id);
            List<Answers> answers = _db.Answer.Where(x => x.QuestionsId == question.Id).ToList();
            foreach (var ans in answers)
            {
                _db.Remove(ans);
            }
            _db.Remove(question);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

}