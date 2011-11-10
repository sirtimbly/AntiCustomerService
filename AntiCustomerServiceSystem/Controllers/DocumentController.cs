using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AntiCustomerServiceSystem.Models;
using System.Web.Helpers;
using System.IO;

namespace AntiCustomerServiceSystem.Controllers
{ 
	public class DocumentController : Controller
	{
		private ServiceSystemContainer db = new ServiceSystemContainer();

		//
		// GET: /Document/

		public ViewResult Index()
		{
			return View(db.Documents.ToList());
		}

		//
		// GET: /Document/Details/5

		public ViewResult Details(int id)
		{
			Document document = db.Documents.Find(id);
			return View(document);
		}

		//
		// GET: /Document/Create

		public ActionResult Create(int? issueId = null, int? companyId = null)
		{
			ViewBag.IssueId = issueId;
			ViewBag.CompanyId = companyId;
			return View();
		}

		public ActionResult Upload(FormCollection form)
		{
			string fileSavePath = "";
			string uploadDir = "/Documents/";
			var uploadedFile = Request.Files[0];
			string fileName = Path.GetFileName(uploadedFile.FileName);
			fileSavePath = Server.MapPath(uploadDir + fileName);
			uploadedFile.SaveAs(fileSavePath);
			Document document = new Document();
			document.Modified = document.Created = DateTime.Now;
			document.URI = uploadDir + fileName;
			if (!String.IsNullOrWhiteSpace(form["issueId"]))
			{
				Issue issue = db.Issues.Find(int.Parse(form["issueId"]));
				document.Issue = issue;
				db.Documents.Add(document);
				db.SaveChanges();
				return RedirectToAction("Details", "Issue", issue);
			}
			if (!String.IsNullOrWhiteSpace(form["companyId"]))
			{
				Company company = db.Companies.Find(int.Parse(form["companyId"]));
				document.Company = company;
				db.Documents.Add(document);
				db.SaveChanges();
				return RedirectToAction("Details", "Company", company);
			}

			return RedirectToAction("Index");
		}

		//
		// POST: /Document/Create

		[HttpPost]
		public ActionResult Create(Document document, FormCollection form)
		{
			if (ModelState.IsValid)
			{
				db.Documents.Add(document);
				db.SaveChanges();
				return RedirectToAction("Index");  
			}

			return View(document);
		}
		
		//
		// GET: /Document/Edit/5
 
		public ActionResult Edit(int id)
		{
			Document document = db.Documents.Find(id);
			return View(document);
		}

		//
		// POST: /Document/Edit/5

		[HttpPost]
		public ActionResult Edit(Document document)
		{
			if (ModelState.IsValid)
			{
				db.Entry(document).State = EntityState.Modified;
				db.SaveChanges();
				return RedirectToAction("Index");
			}
			return View(document);
		}

		//
		// GET: /Document/Delete/5
 
		public ActionResult Delete(int id)
		{
			Document document = db.Documents.Find(id);
			return View(document);
		}

		//
		// POST: /Document/Delete/5

		[HttpPost, ActionName("Delete")]
		public ActionResult DeleteConfirmed(int id)
		{            
			Document document = db.Documents.Find(id);
			db.Documents.Remove(document);
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