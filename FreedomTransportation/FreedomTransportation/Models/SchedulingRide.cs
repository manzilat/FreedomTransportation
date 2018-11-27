using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FreedomTransportation.Models
{
    public class SchedulingRide
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Pickup From")]
        public string PickupAddress { get; set; }
        [Display(Name = "Pickup City")]
        public string PickupCity { get; set; }
        [Display(Name = "Pickup State")]
        public string PickupState{ get; set; }
        [Display(Name = "Pickup ZipCode")]
        public string PickupZipCode { get; set; }
        [Display(Name = "DropOff To")]
        public string DropoffAddress { get; set; }
        [Display(Name = "DropOff City")]
        public string DropoffCity { get; set; }
        [Display(Name = "DropOff State")]
        public string DropoffState { get; set; }
        [Display(Name = "DropOff Zipode")]
        public string DropoffZipCode { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }

        // add foreign key for driver (driver id)
        // make sure DriverId is set when a ride is created!

        // step 3 =>
        // make index view for rides. in controller's Index action, query for rides based on driverId

    }
}