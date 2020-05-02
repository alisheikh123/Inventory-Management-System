using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Management_Systems.Models
{
    public class tblInvoiceDetail
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int invoiceDetailId { get; set; }


        [Required(ErrorMessage = "*Required Invoice ID")]
        [Display(Name = "Invoice ID ")]
        [Remote("GetInvoiceCode", "Home", HttpMethod = "POST", ErrorMessage = "Invoice Code Already Exist.")]
        public int invoiceId { get; set; }

        [Required(ErrorMessage = "*Required Item ID")]
        [Display(Name = "Item ID")]
        public int itemId { get; set; }



        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Price must be numeric")]
        [Display(Name = "Price ")]
        public decimal price { get; set; }

        [Required(ErrorMessage = "*Required Quantity ")]
        [Display(Name = "Quantity")]
        public int Quantity { get; set; }


        
        [Required(ErrorMessage = "*Required  Amount")]
        [Display(Name = "Amount")]
        public decimal amount { get; set; }



        /// <summary>
        /// Forign Keys
        /// </summary>

        [ForeignKey("invoiceId")]
        public virtual tblInvoice TblInvoice { get; set; }

        [ForeignKey("itemId")]
        public virtual tblItem TblItem { get; set; }


    }
}