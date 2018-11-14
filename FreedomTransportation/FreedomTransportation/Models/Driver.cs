﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FreedomTransportation.Models
{
    public class Driver
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "Driver's License")]
        public string DriversLicense { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Status { get; set; }
        [Display(Name = "Driver's Rating")]
        public string DriverRating { get; set; }

        public string lat { get; set; }
        public string lng { get; set; }
    }
}