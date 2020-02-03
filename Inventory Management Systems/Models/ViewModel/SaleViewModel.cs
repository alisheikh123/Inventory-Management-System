using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models.ViewModel
{
    public class SaleViewModel
    {
       
        public List<tblInvoice> tblInvoices { get; set; }
        public List<tblInvoiceDetail> tblInvoiceDetails { get; set; }
        public List<tblItem> tblItems { get; set; }
        public List<tblAccount> tblAccounts { get; set; }
    }
}