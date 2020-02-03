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
    public class tblAccountHeadsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblAccountHeads
        public ActionResult Index()
        {
            return View(db.tblAccountHeads.ToList());
        }

        // GET: tblAccountHeads/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccountHead tblAccountHead = db.tblAccountHeads.Find(id);
            if (tblAccountHead == null)
            {
                return HttpNotFound();
            }
            return View(tblAccountHead);
        }

        // GET: tblAccountHeads/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblAccountHeads/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "accountHeadId,accountHeadName,account_Head_Code")] tblAccountHead tblAccountHead)
        {
            if (ModelState.IsValid)
            {
                db.tblAccountHeads.Add(tblAccountHead);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblAccountHead);
        }

        // GET: tblAccountHeads/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccountHead tblAccountHead = db.tblAccountHeads.Find(id);
            if (tblAccountHead == null)
            {
                return HttpNotFound();
            }
            return View(tblAccountHead);
        }

        // POST: tblAccountHeads/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "accountHeadId,accountHeadName,account_Head_Code")] tblAccountHead tblAccountHead)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblAccountHead).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblAccountHead);
        }

        // GET: tblAccountHeads/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblAccountHead tblAccountHead = db.tblAccountHeads.Find(id);
            if (tblAccountHead == null)
            {
                return HttpNotFound();
            }
            return View(tblAccountHead);
        }

        // POST: tblAccountHeads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblAccountHead tblAccountHead = db.tblAccountHeads.Find(id);
            db.tblAccountHeads.Remove(tblAccountHead);
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
