using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models
{
    public class tblCompany
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int companyId { get; set; }


        [Display(Name = "Company Code")]
        [Required]
        public string CompanyCode { get; set; }

        [Display(Name = "Company Name")]
        [Required]
        public string CompanyName { get; set; }

        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Display(Name = "Phone Number")]
        [DataType(DataType.PhoneNumber, ErrorMessage = "phone is not valid")]
        public string Contact { get; set; }

        [Display(Name = "Web")]
        public string webaddress { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Address")]
        public string Address { get; set; }
    }
}