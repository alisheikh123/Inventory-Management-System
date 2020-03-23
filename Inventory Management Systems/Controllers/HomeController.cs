using Inventory_Management_Systems.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Inventory_Management_Systems.Models.ViewModel;
using System.Web;
using System.Web.Mvc;

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
    }
}