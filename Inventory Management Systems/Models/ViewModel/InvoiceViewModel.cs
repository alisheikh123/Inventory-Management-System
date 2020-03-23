using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models.ViewModel
{
    public class InvoiceViewModel
    {
        public IEnumerable<tblInvoice> tblInvoice { get; set; }
        public IEnumerable<tblCustomer> Customer { get; set; }
        public IEnumerable<tblItem> tblItem { get; set; }
        public IEnumerable<tblOrder> tblOrders { get; set; }
    }
}