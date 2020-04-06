using Inventory_Management_Systems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Inventory_Management_Systems.Models.ViewModel;
using System.Web;
using System.Web.Mvc;
using Inventory_Management_Systems.Models.Class;

namespace Inventory_Management_Systems.Controllers
{
    public class HomeController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext(); 
        public ActionResult Index()
        {
            
            ViewBag.invoiceId = new SelectList(db.tblInvoices, "invoiceId", "invoice_Code");
            ViewBag.CustomerList = new SelectList(db.Customers.OrderBy(x=>x.Name), "customerId","Name");
            ViewBag.ItemList = new SelectList(db.tblItems.OrderBy(x => x.itemName), "itemId", "ItemName");

          

            return View();
        }



        [HttpPost]
        public ActionResult Index([Bind(Include = "invoiceDetailId,invoiceId,itemId,price,Quantity,amount")] tblInvoiceDetail inv)
        {

            if (ModelState.IsValid)
            {
                tblInvoiceDetail obj = new tblInvoiceDetail();

                obj.invoiceDetailId = inv.invoiceDetailId;
                obj.invoiceId = inv.invoiceId;
                obj.itemId = inv.itemId;

                obj.price = inv.price;
                obj.Quantity = inv.Quantity;
                obj.amount = inv.amount;
                db.tblInvoiceDetails.Add(obj);
                db.SaveChanges();




                return Json(obj, JsonRequestBehavior.AllowGet);

            }
            else
            {

                return View();
            }

        }

        [HttpPost]
        public JsonResult GetInvoiceCode(int invoiceId)
        {
            var invcode = db.tblInvoices.Where(x => x.invoiceId > 0).Select(x => x.invoice_Code).FirstOrDefault();
            if (invoiceId.Equals(invcode))
            {
                ModelState.AddModelError("Invoice Code", "Invoice Code Already Exist!");
            }
            return Json(invoiceId, JsonRequestBehavior.AllowGet);

        }

        public ActionResult Deshboard()
        {
            ViewBag.totalCustomers = db.Customers.Count();
            ViewBag.totalProducts = db.tblItems.Count();
            return View();
        }

    

  
        public ActionResult GetItem(int id)
        {
            List<GetItem> getItems = new List<GetItem>();
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

               
                return Json(itemPrice , JsonRequestBehavior.AllowGet);
            }




            return View();

        }

      

    }
}