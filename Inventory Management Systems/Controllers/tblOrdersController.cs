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
    public class tblOrdersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblOrders
        public ActionResult Index()
        {
            var tblOrders = db.tblOrders.Include(t => t.TblItem).Include(t => t.TblItemUnit);
            return View(tblOrders.ToList());
        }

        // GET: tblOrders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrder tblOrder = db.tblOrders.Find(id);
            if (tblOrder == null)
            {
                return HttpNotFound();
            }
            return View(tblOrder);
        }

        // GET: tblOrders/Create
        public ActionResult Create()
        {
            ViewBag.itemName = new SelectList(db.tblItems, "itemId", "ItemCode");
            ViewBag.ItemUnit = new SelectList(db.tblItemUnits, "unitId", "unitName");
            return View();
        }

        // POST: tblOrders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,itemName,ItemUnit,Quantity,price,discount,Amount,totalAmount,AmountPaid,BalanceDue,status,Description,current_Date")] tblOrder tblOrder)
        {
            if (ModelState.IsValid)
            {
                db.tblOrders.Add(tblOrder);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.itemName = new SelectList(db.tblItems, "itemId", "ItemCode", tblOrder.itemName);
            ViewBag.ItemUnit = new SelectList(db.tblItemUnits, "unitId", "unitName", tblOrder.ItemUnit);
            return View(tblOrder);
        }

        // GET: tblOrders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrder tblOrder = db.tblOrders.Find(id);
            if (tblOrder == null)
            {
                return HttpNotFound();
            }
            ViewBag.itemName = new SelectList(db.tblItems, "itemId", "ItemCode", tblOrder.itemName);
            ViewBag.ItemUnit = new SelectList(db.tblItemUnits, "unitId", "unitName", tblOrder.ItemUnit);
            return View(tblOrder);
        }

        // POST: tblOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,itemName,ItemUnit,Quantity,price,discount,Amount,totalAmount,AmountPaid,BalanceDue,status,Description,current_Date")] tblOrder tblOrder)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblOrder).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.itemName = new SelectList(db.tblItems, "itemId", "ItemCode", tblOrder.itemName);
            ViewBag.ItemUnit = new SelectList(db.tblItemUnits, "unitId", "unitName", tblOrder.ItemUnit);
            return View(tblOrder);
        }

        // GET: tblOrders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblOrder tblOrder = db.tblOrders.Find(id);
            if (tblOrder == null)
            {
                return HttpNotFound();
            }
            return View(tblOrder);
        }

        // POST: tblOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblOrder tblOrder = db.tblOrders.Find(id);
            db.tblOrders.Remove(tblOrder);
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
