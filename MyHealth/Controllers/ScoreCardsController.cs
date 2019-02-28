﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MyHealth.DAL;
using MyHealth.Models;

namespace MyHealth.Controllers
{
    public class ScoreCardsController : Controller
    {
        private UserContext db = new UserContext();
    

    public ActionResult CalculateDaily(Log log)
        {
            ScoreCard todayscore = new ScoreCard
            {

                ScoretDate = log.LogtDate,
                DayScore = Convert.ToInt16(log.Meditation + log.Read + log.Veggies + log.Exercise - log.Alcohol),
                WeekScore = 0,
                TotalScore = 0, 
              
        };
            Create(todayscore);
            return View("Index");
        }
        //used for updateing scorecards after log changes
        public ActionResult CalculateUpdate(Log log, User user)
        {
            var scores = db.ScoreCards;
            foreach (ScoreCard s in scores)
            {
                if (s.ScoretDate.Date == log.LogtDate.Date)
                {
                    
                    db.ScoreCards.Remove(s);
                    //db.SaveChanges();
                }
              
            };

            return View("Index");
        }

        public ActionResult UpdateDaily(Log log, DateTime date, User loguser)
        {
            ScoreCard todayscore = new ScoreCard
            {

                ScoretDate = date,
                DayScore =  (11 - Convert.ToInt16(log.Bedtime))*5 +
                            Convert.ToInt16(log.Meditation) +
                            Convert.ToInt16(log.Read) +
                            Convert.ToInt16(log.Veggies)*3 +
                            Convert.ToInt16(log.Exercise) -
                            Convert.ToInt16(log.Alcohol)*10,

                WeekScore = 0,
                TotalScore = 0,
         
            };
            Create(todayscore);
            return View("Index");
        }

      






        // GET: ScoreCards
        public ActionResult Index(string sortOrder)
        {
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "dayscore_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
           
            ViewBag.DayScoreSortParm = sortOrder == "DayScore" ? "DayScore_desc" : "DayScore";
            var scores = from s in db.ScoreCards
                           select s;
            switch (sortOrder)
            {
                case "DayScore":
                    scores = scores.OrderByDescending(s => s.DayScore);
                    break;
                case "Date":
                    scores = scores.OrderBy(s => s.ScoretDate);
                    break;
                case "date_desc":
                    scores = scores.OrderByDescending(s => s.ScoretDate);
                    break;
                default:
                    scores = scores.OrderByDescending(s => s.ScoretDate);
                    break;
            }
            return View(scores.ToList());
        }

        // GET: ScoreCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreCard scoreCard = db.ScoreCards.Find(id);
            if (scoreCard == null)
            {
                return HttpNotFound();
            }
            return View(scoreCard);
        }

        // GET: ScoreCards/Create
        public ActionResult Create()
        {
            return View();
        }

    

        // POST: ScoreCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ScoretDate,DayScore,WeekScore,TotalScore")] ScoreCard scoreCard)
        {
            if (ModelState.IsValid)
            {
                db.ScoreCards.Add(scoreCard);
                db.SaveChanges();
             
                return RedirectToAction("Index");
            }
           

            return View(scoreCard);
        }

        // GET: ScoreCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreCard scoreCard = db.ScoreCards.Find(id);
            if (scoreCard == null)
            {
                return HttpNotFound();
            }
            return View(scoreCard);
        }


        // POST: ScoreCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DEdit([Bind(Include = "ID,ScoretDate,DayScore,WeekScore,TotalScore")] ScoreCard scoreCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scoreCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scoreCard);
        }

        // GET: ScoreCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScoreCard scoreCard = db.ScoreCards.Find(id);
            if (scoreCard == null)
            {
                return HttpNotFound();
            }
            return View(scoreCard);
        }

        // POST: ScoreCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScoreCard scoreCard = db.ScoreCards.Find(id);
            db.ScoreCards.Remove(scoreCard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
