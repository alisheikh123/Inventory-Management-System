using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CrystalDecisions.CrystalReports.Engine;
using Inventory_Management_Systems.Models;

namespace Inventory_Management_Systems.Controllers
{
    public class tblInvoicesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblInvoices
        public ActionResult Index()
        {
            var tblInvoices = db.tblInvoices.Include(t => t.TblAccount).Include(t => t.TblCompany).Include(t => t.TblCustomer);
            return View(tblInvoices.ToList());
        }

        public ActionResult InvoiceReportExport()
        {
     

            var Invoic = db.tblInvoices.Include(t => t.TblAccount).Include(t => t.TblCompany).Include(t => t.TblCustomer);
            List<tblInvoice> list = new List<tblInvoice>();
            list = Invoic.ToList();
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Report"), "InvoiceReport.rpt"));
            rd.SetDataSource(list);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream,"application/pdf","Invoice Report");
            }
            catch {

                throw;
            }
        }


        // GET: tblInvoices/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInvoice tblInvoice = db.tblInvoices.Find(id);
            if (tblInvoice == null)
            {
                return HttpNotFound();
            }
            return View(tblInvoice);
        }

        // GET: tblInvoices/Create
        public ActionResult Create()
        {

            ViewBag.accountId = new SelectList(db.tblAccounts, "accountId", "accountTitle");
            ViewBag.companyId = new SelectList(db.Companies, "companyId", "CompanyName");
            ViewBag.customerId = new SelectList(db.Customers, "customerId", "Name");
            return View();
        }

        // POST: tblInvoices/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "invoiceId,invoice_Code,Invoice_type,payment_Mode,invoice_Date,Due_Date,companyId,accountId,customerId,Created_Date")] tblInvoice tblInvoice)
        {
            if (ModelState.IsValid)
            {
                var invoice = db.tblInvoices.Where(x => x.invoice_Code == tblInvoice.invoice_Code).Count();
                if (invoice > 0)
                {
                    ModelState.AddModelError("invoice_Code", "Invoice Code Already Exist");
                }
                else
                {
                    tblInvoice.Created_Date = DateTime.Now;
                    db.tblInvoices.Add(tblInvoice);
                    db.SaveChanges();
                    return RedirectToAction("Create","tblInvoiceDetails");
                }
            }

            ViewBag.accountId = new SelectList(db.tblAccounts, "accountId", "accountTitle", tblInvoice.accountId);
            ViewBag.companyId = new SelectList(db.Companies, "companyId", "CompanyCode", tblInvoice.companyId);
            ViewBag.customerId = new SelectList(db.Customers, "customerId", "CustomerCode", tblInvoice.customerId);
            return View(tblInvoice);
        }

        // GET: tblInvoices/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInvoice tblInvoice = db.tblInvoices.Find(id);
            if (tblInvoice == null)
            {
                return HttpNotFound();
            }
            ViewBag.accountId = new SelectList(db.tblAccounts, "accountId", "accountTitle", tblInvoice.accountId);
            ViewBag.companyId = new SelectList(db.Companies, "companyId", "CompanyCode", tblInvoice.companyId);
            ViewBag.customerId = new SelectList(db.Customers, "customerId", "CustomerCode", tblInvoice.customerId);
            return View(tblInvoice);
        }

        // POST: tblInvoices/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "invoiceId,invoice_Code,Invoice_type,payment_Mode,invoice_Date,Due_Date,companyId,accountId,customerId,Created_Date")] tblInvoice tblInvoice)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblInvoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.accountId = new SelectList(db.tblAccounts, "accountId", "accountTitle", tblInvoice.accountId);
            ViewBag.companyId = new SelectList(db.Companies, "companyId", "CompanyCode", tblInvoice.companyId);
            ViewBag.customerId = new SelectList(db.Customers, "customerId", "CustomerCode", tblInvoice.customerId);
            return View(tblInvoice);
        }

        // GET: tblInvoices/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblInvoice tblInvoice = db.tblInvoices.Find(id);
            if (tblInvoice == null)
            {
                return HttpNotFound();
            }
            return View(tblInvoice);
        }

        // POST: tblInvoices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblInvoice tblInvoice = db.tblInvoices.Find(id);
            db.tblInvoices.Remove(tblInvoice);
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
