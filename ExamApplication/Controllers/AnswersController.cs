using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ExamApplication.Models;
using Microsoft.AspNetCore.Http;
using ExamApplication.Data;

namespace ExamApplication.Controllers
{
    public class AnswersController : Controller
    {
        private readonly MyDbContext _db;

        public AnswersController(MyDbContext context)
        {
            _db = context;
        }

        [HttpGet]
        public ActionResult Create(int id)
        {
            ViewBag.QuestionsId = id;
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                string ansText = collection["AnsText"].ToString();
                long qId = Convert.ToInt64(collection["QuestionsId"].ToString());

                Answers answer = new Answers();
                answer.AnsText = ansText;
                answer.QuestionsId = qId;
                answer.isActive = true;

                _db.Add(answer);
                _db.SaveChanges();

                return RedirectToAction("Edit", "Questions", new { id = qId });
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult Edit(long id, int qid)
        {
            ViewBag.QuestionsId = qid;
            var answer = _db.Answer.Find(id);
            return View(answer);
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(long id, IFormCollection collection)
        {
            long qId = Convert.ToInt64(collection["QuestionsId"].ToString());
            try
            {
                if (ModelState.IsValid)
                {
                    var answer = _db.Answer.Find(id);
                    answer.AnsText = collection["AnsText"].ToString();
                    answer.isActive = collection["isActive"].ToString().IndexOf("true") != -1;
                    _db.Update(answer);
                    _db.SaveChanges();

                    return RedirectToAction("Edit", "Questions", new { id = qId });
                }
            }
            catch (Exception ex)
            {
                return View();
            }
            return RedirectToAction("Edit", "Questions", new { id = qId });
        }
        public ActionResult Delete(long id, int qid)
        {
            var answer = _db.Answer.Find(id);
            _db.Answer.Remove(answer);
            _db.SaveChanges();
            return RedirectToAction("Edit", "Questions", new { id = qid });
        }
    }
}