using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory_Management_Systems.Models;
using Inventory_Management_Systems.Models.Class;

namespace Inventory_Management_Systems.Controllers
{
    public class tblInvoiceDetailsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblInvoiceDetails
        public ActionResult Index()
        {
            var tblInvoiceDetails = db.tblInvoiceDetails.Include(t => t.TblInvoice).Include(t => t.TblItem);
            return View(tblInvoiceDetails.ToList());
        }

        // GET: tblInvoiceDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInvoiceDetail tblInvoiceDetail = db.tblInvoiceDetails.Find(id);
            if (tblInvoiceDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblInvoiceDetail);
        }

        // GET: tblInvoiceDetails/Create
        public ActionResult Create()
        {
            ViewBag.invoiceId = new SelectList(db.tblInvoices, "invoiceId", "invoice_Code");
            ViewBag.itemId = new SelectList(db.tblItems, "itemId", "itemName");
            return View();
        }

        // POST: tblInvoiceDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "invoiceDetailId,invoiceId,itemId,price,Quantity,amount")] tblInvoiceDetail tblInvoiceDetail)
        {
            if (ModelState.IsValid)
            {
                db.tblInvoiceDetails.Add(tblInvoiceDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.invoiceId = new SelectList(db.tblInvoices, "invoiceId", "invoice_Code", tblInvoiceDetail.invoiceId);
            ViewBag.itemId = new SelectList(db.tblItems, "itemId", "itemName", tblInvoiceDetail.itemId);
            return View(tblInvoiceDetail);
        }

        // GET: tblInvoiceDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInvoiceDetail tblInvoiceDetail = db.tblInvoiceDetails.Find(id);
            if (tblInvoiceDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.invoiceId = new SelectList(db.tblInvoices, "invoiceId", "invoice_Code", tblInvoiceDetail.invoiceId);
            ViewBag.itemId = new SelectList(db.tblItems, "itemId", "ItemCode", tblInvoiceDetail.itemId);
            return View(tblInvoiceDetail);
        }

        // POST: tblInvoiceDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "invoiceDetailId,invoiceId,itemId,price,Quantity,amount")] tblInvoiceDetail tblInvoiceDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblInvoiceDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.invoiceId = new SelectList(db.tblInvoices, "invoiceId", "invoice_Code", tblInvoiceDetail.invoiceId);
            ViewBag.itemId = new SelectList(db.tblItems, "itemId", "ItemCode", tblInvoiceDetail.itemId);
            return View(tblInvoiceDetail);
        }

        // GET: tblInvoiceDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInvoiceDetail tblInvoiceDetail = db.tblInvoiceDetails.Find(id);
            if (tblInvoiceDetail == null)
            {
                return HttpNotFound();
            }
            return View(tblInvoiceDetail);
        }

        // POST: tblInvoiceDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblInvoiceDetail tblInvoiceDetail = db.tblInvoiceDetails.Find(id);
            db.tblInvoiceDetails.Remove(tblInvoiceDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetItem(int id)
        {
           
            var items = from m in db.tblItems
                        select m;

            if (id > 0)
            {
                var itemPrice = items.Where(x => x.itemId.Equals(id)).Select(x => new
                {
                    val = x.itemId,
                    price = x.sale_Price,
                    itemQuantity = x.Quantity

                }).FirstOrDefault();


                return Json(itemPrice, JsonRequestBehavior.AllowGet);
            }




            return View();

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
