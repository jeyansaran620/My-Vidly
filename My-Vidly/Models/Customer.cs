using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Vidly.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter customer's name.")]
        [StringLength(255)]
        public string Name { get; set; }

        [Min18YearsIfAMember]
        [Display(Name = "Date of Birth")]
        public DateTime? DOB { get; set; }

        [Display(Name = "Subscribed to newsletter?")]
        public bool IsSubscribedToNewsletter { get; set; }

        public MembershipType MembershipType { get; set; }
        
        [Display(Name = "Membership Type")]
        public byte MembershipTypeId { get; set; }

        public static readonly byte Unknown = 0;
        public static readonly byte PayasYouGo = 1;
    }
}