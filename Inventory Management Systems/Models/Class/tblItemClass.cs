using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models.Class
{
    public class tblItemClass
    {

      
        public int itemId { get; set; }
        public int categoryId { get; set; }
        public int UnitId { get; set; }
        public string ItemCode { get; set; }
        public string itemName { get; set; }
        public int Quantity { get; set; }
        public decimal purchasePrice { get; set; }
        public decimal salePrice { get; set; }
        public int percentage { get; set; }
        public int alert { get; set; }
    }
}