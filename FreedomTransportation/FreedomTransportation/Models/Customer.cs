using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreedomTransportation.Models
{
    public class Customer
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }

        public string lat { get; set; }
        public string lng { get; set; }
    }
}
//[Display(Name = "Name on the card")]
//public string NameOnTheCard { get; set; }
//[Display(Name = "Credit card Number")]
//public string CreditCard { get; set; }
//[Display(Name = "Expiration Date")]
//public string ExpirationDate { get; set; }
//[Display(Name = "CVV Number")]
//public string CvvNumber { get; set; }