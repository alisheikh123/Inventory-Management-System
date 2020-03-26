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
            var invoiceList = new List<tblInvoice>();
            var CustomerList = new List<tblCustomer>();
            var ItemList = new List<tblItem>();
            var OrderList = new List<tblOrder>();

            ViewBag.CustomerList = new SelectList(db.Customers.OrderBy(x=>x.Name), "customerId","Name");

            var InvoicView = new InvoiceViewModel()
            {
                tblInvoice = invoiceList,
                Customer = CustomerList,
                tblItem = ItemList,
                tblOrders = OrderList

            };

            return View(InvoicView);
        }
        public ActionResult Deshboard()
        {
            ViewBag.totalCustomers = db.Customers.Count();
            ViewBag.totalProducts = db.tblItems.Count();
            return View();
        }
        public ActionResult Puchase()
        {
            ViewBag.Message = "Purchase.";

            return View();
        }
        public ActionResult Sale()
        {
            ViewBag.Message = "Sale.";

            return View();
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        public ActionResult GetItem(string q)
        {
            var list = new List<GetItem>();

            list.Add(new GetItem()
            {
                text = "India",
                id = "101"
            });
            list.Add(new GetItem()
            {
                text = "Srilanka",
                id = "102"
            });
            list.Add(new GetItem()
            {
                text = "Singapore",
                id = "103"
            });

            if (!(string.IsNullOrEmpty(q) || string.IsNullOrWhiteSpace(q)))
            {
                list = list.Where(x => x.text.ToLower().StartsWith(q.ToLower())).ToList();
            }
            return Json(new { items = list }, JsonRequestBehavior.AllowGet);
            
        }

    }
}