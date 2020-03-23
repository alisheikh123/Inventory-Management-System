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
    public class tblItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblItems1
        public ActionResult Index()
        {
            var tblItems = db.tblItems.Include(t => t.category).Include(t => t.Unit);
            return View(tblItems.ToList());
        }

        // GET: tblItems1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItem tblItem = db.tblItems.Find(id);
            if (tblItem == null)
            {
                return HttpNotFound();
            }
            return View(tblItem);
        }

        // GET: tblItems1/Create
        public ActionResult Create()
        {
            ViewBag.catId = new SelectList(db.tblItemcategories, "catId", "catName");
            ViewBag.UnitId = new SelectList(db.tblItemUnits, "unitId", "unitName");
            return View();
        }

        // POST: tblItems1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "itemId,catId,UnitId,ItemCode,itemName,purchase_Price,sale_Price")] tblItem tblItem)
        {
            if (ModelState.IsValid)
            {
                db.tblItems.Add(tblItem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.catId = new SelectList(db.tblItemcategories, "catId", "catName", tblItem.catId);
            ViewBag.UnitId = new SelectList(db.tblItemUnits, "unitId", "unitName", tblItem.UnitId);
            return View(tblItem);
        }

        // GET: tblItems1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItem tblItem = db.tblItems.Find(id);
            if (tblItem == null)
            {
                return HttpNotFound();
            }
            ViewBag.catId = new SelectList(db.tblItemcategories, "catId", "catName", tblItem.catId);
            ViewBag.UnitId = new SelectList(db.tblItemUnits, "unitId", "unitName", tblItem.UnitId);
            return View(tblItem);
        }

        // POST: tblItems1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "itemId,catId,UnitId,ItemCode,itemName,purchase_Price,sale_Price")] tblItem tblItem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblItem).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.catId = new SelectList(db.tblItemcategories, "catId", "catName", tblItem.catId);
            ViewBag.UnitId = new SelectList(db.tblItemUnits, "unitId", "unitName", tblItem.UnitId);
            return View(tblItem);
        }

        // GET: tblItems1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItem tblItem = db.tblItems.Find(id);
            if (tblItem == null)
            {
                return HttpNotFound();
            }
            return View(tblItem);
        }

        // POST: tblItems1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblItem tblItem = db.tblItems.Find(id);
            db.tblItems.Remove(tblItem);
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
