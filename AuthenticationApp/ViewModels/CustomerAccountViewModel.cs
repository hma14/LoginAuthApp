using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AuthenticationApp.ViewModels
{
    public class CustomerAccountViewModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
       
        [Display(Name ="Email")]
        public string EmailAddress { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}