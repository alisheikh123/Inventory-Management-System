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
    public class tblItemcategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblItemcategories
        public ActionResult Index()
        {
            return View(db.tblItemcategories.ToList());
        }

        // GET: tblItemcategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemcategory tblItemcategory = db.tblItemcategories.Find(id);
            if (tblItemcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblItemcategory);
        }

        // GET: tblItemcategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblItemcategories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "catId,catName,catDesc")] tblItemcategory tblItemcategory)
        {
            
            if (ModelState.IsValid)
            {
                var s = db.tblItemcategories.Where(x => x.catName == tblItemcategory.catName).Count();
                if (s > 0)
                {
                    ViewBag.catError = "Category Name Already Exist*";
                }
                else
                {
                    db.tblItemcategories.Add(tblItemcategory);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                }

            return View(tblItemcategory);
        }

        // GET: tblItemcategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemcategory tblItemcategory = db.tblItemcategories.Find(id);
            if (tblItemcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblItemcategory);
        }

        // POST: tblItemcategories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "catId,catName,catDesc")] tblItemcategory tblItemcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblItemcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tblItemcategory);
        }

        // GET: tblItemcategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblItemcategory tblItemcategory = db.tblItemcategories.Find(id);
            if (tblItemcategory == null)
            {
                return HttpNotFound();
            }
            return View(tblItemcategory);
        }

        // POST: tblItemcategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblItemcategory tblItemcategory = db.tblItemcategories.Find(id);
            db.tblItemcategories.Remove(tblItemcategory);
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
