using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreedomTransportation.Models
{
    public class SchedulingRide
    {
        public int SchedulingId { get; set; }

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
        public int DropoffCity { get; set; }
        [Display(Name = "DropOff State")]
        public string DropoffState { get; set; }
        [Display(Name = "DropOff Zipode")]
        public string DropoffZipCode { get; set; }
        public string lat { get; set; }
        public string lng { get; set; }


    }
}