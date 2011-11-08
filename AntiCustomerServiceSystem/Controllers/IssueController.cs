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
	public class IssueController : Controller
	{
		private ServiceSystemContainer db = new ServiceSystemContainer();

		//
		// GET: /Issue/

		public ViewResult Index()
		{
			return View(db.Issues.ToList());
		}

		//
		// GET: /Issue/Details/5

		public ViewResult Details(int id)
		{
			Issue issue = db.Issues.Find(id);
			return View(issue);
		}

		//
		// GET: /Issue/Create

		public ActionResult Create(int? companyId = null)
		{
			if (companyId != null)
			{
				Company owner = db.Companies.Where(c => c.Id == companyId).FirstOrDefault();
				ViewBag.CompanyId = companyId;
			}
			
			Issue newIssue = new Issue
			{
				Opened = DateTime.Now,
				State = IssueState.OPEN
			};
			db.Issues.Add(newIssue);
			db.SaveChanges();
			
			return View("Details", newIssue);
		} 

		//
		// POST: /Issue/Create

		[HttpPost]
		public ActionResult Create(Issue issue, string companyId = null)
		{
			if (ModelState.IsValid)
			{
				if (companyId != null)
					issue.Companies.Add(db.Companies.Find(companyId));
				db.Issues.Add(issue);
				db.SaveChanges();
				return RedirectToAction("Index");  
			}

			return View(issue);
		}
		
		//
		// GET: /Issue/Edit/5
 
		public ActionResult Edit(int id)
		{
			Issue issue = db.Issues.Find(id);
			return View(issue);
		}

		//
		// POST: /Issue/Edit/5

		[HttpPost]
		public ActionResult Edit(Issue issue)
		{
			if (ModelState.IsValid)
			{
				db.Entry(issue).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(issue);
		}

		//
		// GET: /Issue/Delete/5
 
		public ActionResult Delete(int id)
		{
			Issue issue = db.Issues.Find(id);
			return View(issue);
		}

		//
		// POST: /Issue/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{            
			Issue issue = db.Issues.Find(id);
			db.Issues.Remove(issue);
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