using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lively.Models
{
    public class Customer
    {
        public int ID { get; set; }

        [Required(ErrorMessage ="Please Enter Customer's Name")]
        [StringLength(255)]
        public String Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public MembershipType MembershipType { get; set; }

        [Display(Name = "Membership Type")]
        public byte MembershipTypeID { get; set; }

        [Display(Name ="Date of Birth")]
        [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}