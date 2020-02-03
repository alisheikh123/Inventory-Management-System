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
            var invoices = db.tblInvoices.ToList<tblInvoice>();
            var invoice_detail = db.tblInvoiceDetails.ToList<tblInvoiceDetail>();
            var itemlist = db.tblItems.ToList<tblItem>();
            var accounts = db.tblAccounts.ToList<tblAccount>();

            var SaleViewModel = new SaleViewModel
            {
                tblInvoices = invoices,
                tblInvoiceDetails = invoice_detail,
                tblItems = itemlist,
                tblAccounts = accounts

            };

            return View(SaleViewModel);
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