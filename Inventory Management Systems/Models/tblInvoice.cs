using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models
{
    public class tblInvoice
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int invoiceId { get; set; }


        [Required(ErrorMessage = "*Required Invoice Code")]
        [Display(Name = "Invoice Code :")]
        public string invoice_Code { get; set; }

        [Required(ErrorMessage = "*Required Invoice Type")]
        [Display(Name = "Invoice Type:")]
        public InvoicesType Invoice_type { get; set; }

        [Display(Name = "Payment Mode :")]      
        public paymentMode payment_Mode { get; set; }

        [Required(ErrorMessage = "*Required Invoice Date ")]
        [DataType(DataType.Date),DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}"),]       
        [Display(Name = "Invoice Date :")]
        public DateTime invoice_Date { get; set; }

        [Required(ErrorMessage = "*Required Due Date ")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Due Date :")]
        public DateTime Due_Date { get; set; }

        [Required(ErrorMessage = "*Required Company Name")]
        [Display(Name = "Company Name :")]
        public int companyId { get; set; }


        //Account Table Data
        [Required(ErrorMessage = "*Required Account Name")]
        [Display(Name = "Account Name :")]
        public int accountId { get; set; }


        [Required(ErrorMessage = "*Required Customer Name")]
        [Display(Name = "Customer Name :")]
        public int customerId { get; set; }




        [Required(ErrorMessage = "*Required Created Date")]
        [DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Created Date :")]
        public DateTime Created_Date { get; set; }




        [ForeignKey("accountId")]
        public virtual tblAccount TblAccount { get; set; }

        [ForeignKey("companyId")]
        public virtual tblCompany TblCompany { get; set; }

        [ForeignKey("customerId")]
        public virtual tblCustomer TblCustomer { get; set; }


    }

   public enum InvoicesType
    {
        Standard = 0,
        Proforma = 1

    }
    public enum paymentMode
    {
        Cheque =0,
        Cash = 1,
        Credit_Card=2

    }
}