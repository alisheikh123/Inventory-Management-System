using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models.ViewModel
{
    public class InvoiceViewModel
    {
        public List<tblInvoice> tblInvoice { get; set; }
        public List<tblCustomer> Customer { get; set; }
    }
}