using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models
{
    public class Sale
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "*Required Product Name")]
        [Display(Name = "Product Name ")]
        public int ProductName { get; set; }

        [Required(ErrorMessage = "*Required Unit")]
        [Display(Name = "Unit ")]
        public int unit { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="0:yyyy:MM:DD")]
        [Display(Name = "Current Date ")]
        public DateTime current_Date { get; set; }

        [Display(Name = "Customer Name ")]
        public string customerName { get; set; }

        [DataType(DataType.MultilineText)]
        [Range(1,1000)]
        public string Address { get; set; }

        [DataType(DataType.PhoneNumber)]
        [DisplayFormat(DataFormatString = "0:9999999:9999")]
        [Range(1, 10)]
        public int phone { get; set; }

       
        [Display(Name = "Discount ")]
        public double discount { get; set; }

        [Display(Name = "Price ")]
        public double  price { get; set; }


        [ForeignKey("ProductName")]
        public virtual tblItem TblItem { get; set; }


       


    }
}