using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ExcelDataReader;
using Inventory_Management_Systems.Models;
using Inventory_Management_Systems.Models.Class;

namespace Inventory_Management_Systems.Controllers
{
    public class tblItemcategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public ActionResult UploadFileCategory() 
        {
            return View();
        }

        

        //Import Data of Category

        [HttpPost]
        public async Task<ActionResult> ImportCatRecord(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                var fileData = GetDataFromCSVFile(importFile.InputStream);

                var dttblcategory = fileData.ToDataTable();
                var dttblcategoryParameter = new SqlParameter("tblCategoryvar", SqlDbType.Structured)
                {
                    TypeName = "dbo.tblTypeCategory",
                    Value = dttblcategory
                };
                await db.Database.ExecuteSqlCommandAsync("EXEC SPBulkAddCategory @tblCategoryvar", dttblcategoryParameter);
                return Json(new { Status = 1, Message = "File Imported Successfully " });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }

        //Get Data From CSV File Of TblCategory

        private List<tblCategoryClass> GetDataFromCSVFile(Stream stream)
        {
            var categoryList = new List<tblCategoryClass>();
            try
            {
                using (var reader = ExcelReaderFactory.CreateCsvReader(stream))
                {
                    var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration
                    {
                        ConfigureDataTable = _ => new ExcelDataTableConfiguration
                        {
                            UseHeaderRow = true // To set First Row As Column Names  
                        }
                    });

                    if (dataSet.Tables.Count > 0)
                    {
                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow objDataRow in dataTable.Rows)
                        {
                            if (objDataRow.ItemArray.All(x => string.IsNullOrEmpty(x?.ToString()))) continue;
                            categoryList.Add(new tblCategoryClass()
                            {
                                Id = Convert.ToInt32(objDataRow["ID"].ToString()),
                                CategoryName = objDataRow["Name"].ToString(),
                              
                            });
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            return categoryList;
        }

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
