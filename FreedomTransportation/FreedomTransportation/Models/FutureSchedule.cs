using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace FreedomTransportation.Models
{
    public class FutureSchedule
    {
        [Key]
        public int PickUpId { get; set; }
        [ForeignKey("Customer")]
        public int? CustomerId { get; set; }
        public Customer Customer { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Date Of Pickup is Required")]
        [Column(TypeName = "datetime2")]
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Time Required")]
        public string Time { get; set; }
        public string PickupAddress { get; set; }
        public string DropoffAddress { get; set; }
        public string Email { get; set; }
        [ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}