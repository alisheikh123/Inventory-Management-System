using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models
{
    public class tblOrder
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Required Item Name")]
        [Display(Name = "Item Name ")]
        public int itemName { get; set; }

        
        [Display(Name = "Unit ")]
        public int? ItemUnit { get; set; }


        [Display(Name = "Quantity ")]
        public int Quantity { get; set; }


        [Display(Name = "Price ")]
        public decimal price { get; set; }

        [Display(Name = "Discount ")]
        public double discount { get; set; }

        [Display(Name = "Amount ")]
        public decimal Amount { get; set; }

        [Display(Name = "total Amount ")]
        public decimal totalAmount { get; set; }

        [Display(Name = "Amount Paid ")]
        public decimal AmountPaid { get; set; }

        [Display(Name = "Balance Due ")]
        public decimal BalanceDue { get; set; }

        [Display(Name = "Order status ")]
        public orderstatus status { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Description ")]
        public string Description { get; set; }

      

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "0:yyyy:MM:DD")]
        [Display(Name = "Current Date ")]
        public DateTime current_Date { get; set; }


        [ForeignKey("itemName ")]
        public virtual tblItem TblItem { get; set; }

        //[ForeignKey("ItemUnit")]
        //public virtual tblItemUnit TblItemUnit { get; set; }



    }

    public enum orderstatus
    {
        Due = 0,
        Paid = 1,
       

    }
}