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
    public class tblItemsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult uploadItemFile()
        {
            return View();
        }


        [HttpPost]
        public async Task<ActionResult> importItemRecord(HttpPostedFileBase importFile)
        {
            if (importFile == null) return Json(new { Status = 0, Message = "No File Selected" });

            try
            {
                var fileData = GetDataFromCSVFile(importFile.InputStream);

                var dttblItem = fileData.ToDataTable();
                var dttblItemParameter = new SqlParameter("tblType", SqlDbType.Structured)
                {
                    TypeName = "dbo.tblTypeItem",
                    Value = dttblItem
                };
                await db.Database.ExecuteSqlCommandAsync("EXEC spBulkImportItems @tblType", dttblItemParameter);
                return Json(new { Status = 1, Message = "File Imported Successfully " });
            }
            catch (Exception ex)
            {
                return Json(new { Status = 0, Message = ex.Message });
            }
        }

        //Get Data From CSV File Of TblCategory

        private List<tblItemClass> GetDataFromCSVFile(Stream stream)
        {
            var ItemList = new List<tblItemClass>();
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
                            ItemList.Add(new tblItemClass()
                            {
                                itemId = Convert.ToInt32(objDataRow["itemId"].ToString()),
                                categoryId = Convert.ToInt32(objDataRow["categoryId"].ToString()),
                                UnitId = Convert.ToInt32(objDataRow["UnitId"].ToString()),
                                ItemCode = objDataRow["ItemCode"].ToString(),
                                itemName = objDataRow["itemName"].ToString(),
                                Quantity = Convert.ToInt32(objDataRow["Quantity"].ToString()),
                                purchasePrice = Convert.ToDecimal(objDataRow["purchasePrice"].ToString()),
                                salePrice = Convert.ToDecimal(objDataRow["salePrice"].ToString()),
                                percentage = Convert.ToInt32(objDataRow["percentage"].ToString()),
                                alert = Convert.ToInt32(objDataRow["alert"].ToString()),
                            


                            });
                        }
                    }

                }
            }
            catch (Exception)
            {
                throw;
            }

            return ItemList;
        }










        // GET: tblItems
        public ActionResult Index()
        {
            var tblItems = db.tblItems.Include(t => t.category).Include(t => t.Unit);
            return View(tblItems.ToList());
        }

        // GET: tblItems/Details/5
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

        // GET: tblItems/Create
        public ActionResult Create()
        {
            ViewBag.catId = new SelectList(db.tblItemcategories, "catId", "catName");
            ViewBag.UnitId = new SelectList(db.tblItemUnits, "unitId", "unitName");
            return View();
        }

        // POST: tblItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "itemId,catId,UnitId,ItemCode,itemName,Quantity,purchase_Price,sale_Price,Percentage,Alert")] tblItem tblItem)
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

        // GET: tblItems/Edit/5
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

        // POST: tblItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "itemId,catId,UnitId,ItemCode,itemName,Quantity,purchase_Price,sale_Price,Percentage,Alert")] tblItem tblItem)
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

        // GET: tblItems/Delete/5
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

        // POST: tblItems/Delete/5
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
