using System;
using System.Collections.Generic;

namespace AuthenticationApp.Models
{
    public partial class CustomerAccount
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
    }
}
