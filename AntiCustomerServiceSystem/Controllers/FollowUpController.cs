using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AntiCustomerServiceSystem.Models;

namespace AntiCustomerServiceSystem.Controllers
{ 
    public class FollowUpController : Controller
    {
        private ServiceSystemContainer db = new ServiceSystemContainer();

        //
        // GET: /FollowUp/

        public ViewResult Index()
        {
            return View(db.FollowUps.ToList());
        }

        //
        // GET: /FollowUp/Details/5

        public ViewResult Details(int id)
        {
            FollowUp followup = db.FollowUps.Find(id);
            return View(followup);
        }

        //
        // GET: /FollowUp/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /FollowUp/Create

        [HttpPost]
        public ActionResult Create(FollowUp followup)
        {
            if (ModelState.IsValid)
            {
                db.FollowUps.Add(followup);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(followup);
        }
        
        //
        // GET: /FollowUp/Edit/5
 
        public ActionResult Edit(int id)
        {
            FollowUp followup = db.FollowUps.Find(id);
            return View(followup);
        }

        //
        // POST: /FollowUp/Edit/5

        [HttpPost]
        public ActionResult Edit(FollowUp followup)
        {
            if (ModelState.IsValid)
            {
                db.Entry(followup).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(followup);
        }

        //
        // GET: /FollowUp/Delete/5
 
        public ActionResult Delete(int id)
        {
            FollowUp followup = db.FollowUps.Find(id);
            return View(followup);
        }

        //
        // POST: /FollowUp/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            FollowUp followup = db.FollowUps.Find(id);
            db.FollowUps.Remove(followup);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}