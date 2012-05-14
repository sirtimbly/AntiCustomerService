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
	public class CallController : Controller
	{
		private ServiceSystemContainer db = new ServiceSystemContainer();

		//
		// GET: /Call/

		public ViewResult Index()
		{
			return View(db.Calls.ToList());
		}

		//
		// GET: /Call/Details/5

		public ViewResult Details(int id)
		{
			Call call = db.Calls.Find(id);
			return View(call);
		}


		public ActionResult NewWizard()
		{
			List<Issue> issues = db.Issues.ToList();
			return View(issues);
		}

		//
		// GET: /Call/Create

		public ActionResult Create(int issueId)
		{
			Issue issue = db.Issues.Find(issueId);
			
			Call newCall = new Call()
			{
				StartTime = DateTime.Now,
				Issue = issue
			};
			if (issue != null && issue.Companies != null)
			{
				List<SelectListItem> companyList = new List<SelectListItem>();
				foreach (Company item in issue.Companies)
				{
					SelectListItem entry = new SelectListItem
					{
						Text = item.Name,
						Value = item.Id.ToString()
					};
					companyList.Add(entry);
				}
				ViewBag.CompanyList = companyList;
			}
			return View(newCall);
		} 

		//
		// POST: /Call/Create

		[HttpPost]
		public ActionResult Create(Call call, FormCollection form)
		{
			int? issueId = int.Parse(form["issueId"]);
			if (ModelState.IsValid)
			{
				if (issueId > 0)
				{
					call.Issue = db.Issues.Where(i => i.Id == issueId).FirstOrDefault();
					call.Issue.Modified = DateTime.Now;
				}
				db.Calls.Add(call);
				db.SaveChanges();
				return RedirectToAction("Details", "Issue", db.Issues.Find(issueId));  
			}

			return View(call);
		}
		
		//
		// GET: /Call/Edit/5
 
		public ActionResult Edit(int id)
		{
			Call call = db.Calls.Find(id);
			return View(call);
		}

		//
		// POST: /Call/Edit/5

		[HttpPost]
		public ActionResult Edit(Call call)
		{
			if (ModelState.IsValid)
			{
				db.Entry(call).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Details", call);
			}
			return View(call);
		}

		//
		// GET: /Call/Delete/5
 
		public ActionResult Delete(int id)
		{
			Call call = db.Calls.Find(id);
			return View(call);
		}

		//
		// POST: /Call/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{            
			Call call = db.Calls.Find(id);
			db.Calls.Remove(call);
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