using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Inventory_Management_Systems.Models
{
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userId { get; set; }


       
        [Display(Name = "Email :")]
        [DataType(DataType.EmailAddress, ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "*User Name")]
        [Display(Name = "User Name:")]
        public string username { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "*Required Password ")]
        public string password { get; set; }

    }
}