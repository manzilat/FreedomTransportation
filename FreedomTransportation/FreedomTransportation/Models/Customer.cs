using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FreedomTransportation.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
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
        [ForeignKey("CustomerWallet")]
        public int CustomerId { get; set; }
        public CustomerWallet CustomerWallet { get; set; }
        [ForeignKey("SchedulingRide")]
        public int SchedulingRideId { get; set; }
        public SchedulingRide SchedulingRide { get; set; }
    }
}
