using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreedomTransportation.Models
{
    public class Trips
    {
        public int Id { get; set; }
        [Display(Name = "PickUp Time")]
        public DateTime PickUpTime { get; set; }
        [Display(Name = "Arrival Time")]
        public DateTime ArrivalTime { get; set; }
        [Display(Name = "Departure Time")]
        public DateTime DepartureTime { get; set; }
        [Display(Name = "DropOff Time")]
        public DateTime DropOffTime { get; set; }

    }
}