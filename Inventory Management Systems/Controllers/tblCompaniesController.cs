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
    public class tblCompaniesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: tblCompanies
        public async Task<ActionResult> Index()
        {
            return View(await db.Companies.ToListAsync());
        }

        // GET: tblCompanies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCompany tblCompany = await db.Companies.FindAsync(id);
            if (tblCompany == null)
            {
                return HttpNotFound();
            }
            return View(tblCompany);
        }

        // GET: tblCompanies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: tblCompanies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "companyId,CompanyCode,CompanyName,Email,Contact,webaddress,Address")] tblCompany tblCompany)
        {
            if (ModelState.IsValid)
            {
                var checkCompanyCode = db.Companies.Where(x => x.CompanyCode == tblCompany.CompanyCode).Count();
                if (checkCompanyCode > 0)
                {
                    ModelState.AddModelError("CompanyCode", "Company Code Already Exist!");
                }
                else
                {
                    db.Companies.Add(tblCompany);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
                }

            return View(tblCompany);
        }

        // GET: tblCompanies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCompany tblCompany = await db.Companies.FindAsync(id);
            if (tblCompany == null)
            {
                return HttpNotFound();
            }
            return View(tblCompany);
        }

        // POST: tblCompanies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "companyId,CompanyCode,CompanyName,Email,Contact,webaddress,Address")] tblCompany tblCompany)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblCompany).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tblCompany);
        }

        // GET: tblCompanies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblCompany tblCompany = await db.Companies.FindAsync(id);
            if (tblCompany == null)
            {
                return HttpNotFound();
            }
            return View(tblCompany);
        }

        // POST: tblCompanies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            tblCompany tblCompany = await db.Companies.FindAsync(id);
            db.Companies.Remove(tblCompany);
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
