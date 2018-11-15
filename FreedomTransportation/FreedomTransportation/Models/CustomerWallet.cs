using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreedomTransportation.Models
{
    public class CustomerWallet
    {
        [Key]
        public int Id { get; set; }
        public Double Amount { get; set; }
        [Display(Name = "Name on the card")]
        public string NameOnTheCard { get; set; }
        [Display(Name = "Credit card Number")]
        public string CreditCard { get; set; }
        [Display(Name = "Expiration Date")]
        public string ExpirationDate { get; set; }
        [Display(Name = "CVV Number")]
        public string CvvNumber { get; set; }
        
    }
}