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
    public class tblItemUnitsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblItemUnits
        public ActionResult Index()
        {
            return View(db.tblItemUnits.ToList());
        }

        // GET: tblItemUnits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemUnit tblItemUnit = db.tblItemUnits.Find(id);
            if (tblItemUnit == null)
            {
                return HttpNotFound();
            }
            return View(tblItemUnit);
        }

        // GET: tblItemUnits/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblItemUnits/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "unitId,unitName")] tblItemUnit tblItemUnit)
        {
            if (ModelState.IsValid)
            {
                db.tblItemUnits.Add(tblItemUnit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tblItemUnit);
        }

        // GET: tblItemUnits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemUnit tblItemUnit = db.tblItemUnits.Find(id);
            if (tblItemUnit == null)
            {
                return HttpNotFound();
            }
            return View(tblItemUnit);
        }

        // POST: tblItemUnits/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "unitId,unitName")] tblItemUnit tblItemUnit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblItemUnit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblItemUnit);
        }

        // GET: tblItemUnits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemUnit tblItemUnit = db.tblItemUnits.Find(id);
            if (tblItemUnit == null)
            {
                return HttpNotFound();
            }
            return View(tblItemUnit);
        }

        // POST: tblItemUnits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblItemUnit tblItemUnit = db.tblItemUnits.Find(id);
            db.tblItemUnits.Remove(tblItemUnit);
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
