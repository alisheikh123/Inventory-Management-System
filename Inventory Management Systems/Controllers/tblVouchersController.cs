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
    public class tblVouchersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblVouchers
        public ActionResult Index()
        {
            var tblVouchers = db.tblVouchers.Include(t => t.TblInvoice);
            return View(tblVouchers.ToList());
        }

        // GET: tblVouchers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVoucher tblVoucher = db.tblVouchers.Find(id);
            if (tblVoucher == null)
            {
                return HttpNotFound();
            }
            return View(tblVoucher);
        }

        // GET: tblVouchers/Create
        public ActionResult Create()
        {
            ViewBag.invoiceId = new SelectList(db.tblInvoices, "invoiceId", "invoice_Code");
            return View();
        }

        // POST: tblVouchers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "voucherId,voucherCode,voucherDate,invoiceId,userId,createdDate,voucher_Type")] tblVoucher tblVoucher)
        {
            if (ModelState.IsValid)
            {
                db.tblVouchers.Add(tblVoucher);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.invoiceId = new SelectList(db.tblInvoices, "invoiceId", "invoice_Code", tblVoucher.invoiceId);
            return View(tblVoucher);
        }

        // GET: tblVouchers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVoucher tblVoucher = db.tblVouchers.Find(id);
            if (tblVoucher == null)
            {
                return HttpNotFound();
            }
            ViewBag.invoiceId = new SelectList(db.tblInvoices, "invoiceId", "invoice_Code", tblVoucher.invoiceId);
            return View(tblVoucher);
        }

        // POST: tblVouchers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "voucherId,voucherCode,voucherDate,invoiceId,userId,createdDate,voucher_Type")] tblVoucher tblVoucher)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblVoucher).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.invoiceId = new SelectList(db.tblInvoices, "invoiceId", "invoice_Code", tblVoucher.invoiceId);
            return View(tblVoucher);
        }

        // GET: tblVouchers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblVoucher tblVoucher = db.tblVouchers.Find(id);
            if (tblVoucher == null)
            {
                return HttpNotFound();
            }
            return View(tblVoucher);
        }

        // POST: tblVouchers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblVoucher tblVoucher = db.tblVouchers.Find(id);
            db.tblVouchers.Remove(tblVoucher);
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
