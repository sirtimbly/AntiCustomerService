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
	public class CompanyController : Controller
	{
		private ServiceSystemContainer db = new ServiceSystemContainer();

		//
		// GET: /Company/

		public ViewResult Index()
		{
			return View(db.Companies.ToList());
		}

		//
		// GET: /Company/Details/5

		public ViewResult Details(int id)
		{
			Company company = db.Companies.Find(id);
			return View(company);
		}

		//
		// GET: /Company/Create

		public ActionResult Create()
		{
			return View();
		} 

		//
		// POST: /Company/Create

		[HttpPost]
		public ActionResult Create(Company company)
		{
			if (ModelState.IsValid)
			{
				db.Companies.Add(company);
				db.SaveChanges();
				return RedirectToAction("Index");  
			}

			return View(company);
		}
		
		//
		// GET: /Company/Edit/5
 
		public ActionResult Edit(int id)
		{
			Company company = db.Companies.Find(id);
			return View(company);
		}

		//
		// POST: /Company/Edit/5

		[HttpPost]
		public ActionResult Edit(Company company)
		{
			if (ModelState.IsValid)
			{
				db.Entry(company).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(company);
		}

		//
		// GET: /Company/Delete/5
 
		public ActionResult Delete(int id)
		{
			Company company = db.Companies.Find(id);
			return View(company);
		}

		//
		// POST: /Company/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{            
			Company company = db.Companies.Find(id);
			db.Companies.Remove(company);
			db.SaveChanges();
			return RedirectToAction("Index");
		}

		protected override void Dispose(bool disposing)
		{
			db.Dispose();
			base.Dispose(disposing);
		}

		public ActionResult ListPicker(int issueId)
		{
			List<Company> excluded = new List<Company>();
			List<Company> companies = db.Companies.ToList();
			if (issueId != null)
			{
				Issue issue = db.Issues.Find(issueId);
				excluded = issue.Companies.ToList();
				
			}
			ViewBag.IssueId = issueId;
			
			return View();
		}

		public ActionResult AssignToIssue(int companyId, int issueId)
		{
			Company company = db.Companies.Find(companyId);
			Issue issue = db.Issues.Find(issueId);
			issue.Companies.Add(company);
			db.Entry(issue).State = EntityState.Modified;
			db.SaveChanges();
			return RedirectToAction("Details", "Issue", issue);
		}
	}
}