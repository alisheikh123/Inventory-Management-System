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
    public class tblVoucherDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblVoucherDetails
        public ActionResult Index()
        {
            var tblVoucherDetails = db.tblVoucherDetails.Include(t => t.TblVoucher);
            return View(tblVoucherDetails.ToList());
        }

        // GET: tblVoucherDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVoucherDetail tblVoucherDetail = db.tblVoucherDetails.Find(id);
            if (tblVoucherDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblVoucherDetail);
        }

        // GET: tblVoucherDetails/Create
        public ActionResult Create()
        {
            ViewBag.voucherId = new SelectList(db.tblVouchers, "voucherId", "voucherCode");
            return View();
        }

        // POST: tblVoucherDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "voucherdetailId,voucherId,Narration,debitAmount,creditAmount")] tblVoucherDetail tblVoucherDetail)
        {
            if (ModelState.IsValid)
            {
                db.tblVoucherDetails.Add(tblVoucherDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.voucherId = new SelectList(db.tblVouchers, "voucherId", "voucherCode", tblVoucherDetail.voucherId);
            return View(tblVoucherDetail);
        }

        // GET: tblVoucherDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVoucherDetail tblVoucherDetail = db.tblVoucherDetails.Find(id);
            if (tblVoucherDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.voucherId = new SelectList(db.tblVouchers, "voucherId", "voucherCode", tblVoucherDetail.voucherId);
            return View(tblVoucherDetail);
        }

        // POST: tblVoucherDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "voucherdetailId,voucherId,Narration,debitAmount,creditAmount")] tblVoucherDetail tblVoucherDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVoucherDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.voucherId = new SelectList(db.tblVouchers, "voucherId", "voucherCode", tblVoucherDetail.voucherId);
            return View(tblVoucherDetail);
        }

        // GET: tblVoucherDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVoucherDetail tblVoucherDetail = db.tblVoucherDetails.Find(id);
            if (tblVoucherDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblVoucherDetail);
        }

        // POST: tblVoucherDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVoucherDetail tblVoucherDetail = db.tblVoucherDetails.Find(id);
            db.tblVoucherDetails.Remove(tblVoucherDetail);
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
