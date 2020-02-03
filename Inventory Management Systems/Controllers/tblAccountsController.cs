using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory_Management_Systems.Models;

namespace Inventory_Management_Systems.Controllers
{
    public class tblAccountsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblAccounts
        public ActionResult Index()
        {
            var tblAccounts = db.tblAccounts.Include(t => t.TblAccountHead);
            return View(tblAccounts.ToList());
        }

        // GET: tblAccounts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccount tblAccount = db.tblAccounts.Find(id);
            if (tblAccount == null)
            {
                return HttpNotFound();
            }
            return View(tblAccount);
        }

        // GET: tblAccounts/Create
        public ActionResult Create()
        {
            ViewBag.accountHeadId = new SelectList(db.tblAccountHeads, "accountHeadId", "accountHeadName");
            return View();
        }

        // POST: tblAccounts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "accountId,accountHeadId,accountCode,accountTitle,PhoneNo,MobileNo,Email,Address")] tblAccount tblAccount)
        {
            if (ModelState.IsValid)
            {
                db.tblAccounts.Add(tblAccount);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.accountHeadId = new SelectList(db.tblAccountHeads, "accountHeadId", "accountHeadName", tblAccount.accountHeadId);
            return View(tblAccount);
        }

        // GET: tblAccounts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccount tblAccount = db.tblAccounts.Find(id);
            if (tblAccount == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountHeadId = new SelectList(db.tblAccountHeads, "accountHeadId", "accountHeadName", tblAccount.accountHeadId);
            return View(tblAccount);
        }

        // POST: tblAccounts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "accountId,accountHeadId,accountCode,accountTitle,PhoneNo,MobileNo,Email,Address")] tblAccount tblAccount)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAccount).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountHeadId = new SelectList(db.tblAccountHeads, "accountHeadId", "accountHeadName", tblAccount.accountHeadId);
            return View(tblAccount);
        }

        // GET: tblAccounts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccount tblAccount = db.tblAccounts.Find(id);
            if (tblAccount == null)
            {
                return HttpNotFound();
            }
            return View(tblAccount);
        }

        // POST: tblAccounts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAccount tblAccount = db.tblAccounts.Find(id);
            db.tblAccounts.Remove(tblAccount);
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
