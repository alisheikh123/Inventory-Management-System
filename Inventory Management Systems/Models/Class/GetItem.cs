using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models.Class
{
    public class GetItem
    {

        public int invoiceDetailId { get; set; }


        public int invoiceId { get; set; }

        public int itemId { get; set; }


        public decimal price { get; set; }

     
        public int Quantity { get; set; }



        public decimal amount { get; set; }


    }
}