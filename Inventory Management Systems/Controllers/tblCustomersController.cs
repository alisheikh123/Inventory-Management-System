using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventory_Management_Systems.Models;

namespace Inventory_Management_Systems.Controllers
{
    public class tblCustomersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblCustomers
        public async Task<ActionResult> Index()
        {
            return View(await db.Customers.ToListAsync());
        }

        // GET: tblCustomers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustomer tblCustomer = await db.Customers.FindAsync(id);
            if (tblCustomer == null)
            {
                return HttpNotFound();
            }
            return View(tblCustomer);
        }

        // GET: tblCustomers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblCustomers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "customerId,CustomerCode,Name,Email,Contact,Address")] tblCustomer tblCustomer)
        {
            if (ModelState.IsValid)
            {
                var checkCompanyCode = db.Customers.Where(x => x.CustomerCode == tblCustomer.CustomerCode).Count();
                if (checkCompanyCode > 0)
                {
                    ModelState.AddModelError("CustomerCode", "Customer Code Already Exist!");
                }
                else
                {
                    db.Customers.Add(tblCustomer);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }

            return View(tblCustomer);
        }

        // GET: tblCustomers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustomer tblCustomer = await db.Customers.FindAsync(id);
            if (tblCustomer == null)
            {
                return HttpNotFound();
            }
            return View(tblCustomer);
        }

        // POST: tblCustomers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "customerId,CustomerCode,Name,Email,Contact,Address")] tblCustomer tblCustomer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCustomer).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblCustomer);
        }

        // GET: tblCustomers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCustomer tblCustomer = await db.Customers.FindAsync(id);
            if (tblCustomer == null)
            {
                return HttpNotFound();
            }
            return View(tblCustomer);
        }

        // POST: tblCustomers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblCustomer tblCustomer = await db.Customers.FindAsync(id);
            db.Customers.Remove(tblCustomer);
            await db.SaveChangesAsync();
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
