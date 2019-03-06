using System;
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
    public class LogsController : Controller
    {
        private UserContext db = new UserContext();

        // GET: Logs
        public ActionResult Index(string sortOrder)
        {
            ViewBag.DateSortParm = String.IsNullOrEmpty(sortOrder) ? "date_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";
            var logs = from s in db.Logs
                         select s;
            switch (sortOrder)
            {
                case "Date":
                    logs = logs.OrderByDescending(s => s.LogtDate);
                    break;
                case "date_desc":
                    logs = logs.OrderBy(s => s.LogtDate);
                    break;
                default:
                    logs = logs.OrderByDescending(s => s.LogtDate);
                    break;
            }
                    return View(logs.ToList());
        }

        // GET: Logs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log log = db.Logs.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // GET: Logs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Logs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Bedtime,Alcohol,Exercise,Veggies,Meditation,Read")] Log log)
        {
            log.LogtDate = DateTime.Now;
            if (ModelState.IsValid)
            {
            
                db.Logs.Add(log);
                db.SaveChanges();
                //added next 2 lines to create scorecard entry for each log
                var controller = DependencyResolver.Current.GetService<ScoreCardsController>();
                //controller.CalculateDaily(log);
                controller.UpdateDaily(log, log.LogtDate, log.user);
                return RedirectToAction("Index");
                
               
               
            }
            
            return View(log);
        }

        // GET: Logs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log log = db.Logs.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // POST: Logs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,LogtDate,Bedtime,Alcohol,Exercise,Veggies,Meditation,Read")] Log log)
        {
            if (ModelState.IsValid)
            {
                db.Entry(log).State = EntityState.Modified;
                db.SaveChanges();
                //attempt to update scorecard with changes to log 
                 
                var controller = DependencyResolver.Current.GetService<ScoreCardsController>();
                controller.CalculateUpdate(log, log.user);
                controller.UpdateDaily(log, log.LogtDate, log.user);
                return RedirectToAction("Index");
            }
            return View(log);
        }

        // GET: Logs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Log log = db.Logs.Find(id);
            if (log == null)
            {
                return HttpNotFound();
            }
            return View(log);
        }

        // POST: Logs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Log log = db.Logs.Find(id);
            ScoreCard scoreCard = db.ScoreCards.Find(id);
            var controller = DependencyResolver.Current.GetService<ScoreCardsController>();
            controller.Delete(scoreCard.ID);
            db.Logs.Remove(log);
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
