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

		//
		// GET: /Call/Create

		public ActionResult Create(int issueId)
		{
			ViewBag.IssueId = issueId;
			return View();
		} 

		//
		// POST: /Call/Create

		[HttpPost]
		public ActionResult Create(Call call, FormCollection form)
		{
			if (ModelState.IsValid)
			{
				if (!String.IsNullOrWhiteSpace(form["issueId"]))
					call.Issue = db.Issues.Where(i => i.Id == int.Parse(form["issueId"])).FirstOrDefault();

				db.Calls.Add(call);
				db.SaveChanges();
				return RedirectToAction("Index");  
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
				return RedirectToAction("Index");
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