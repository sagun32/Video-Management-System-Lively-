using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lively.Models;
using System.ComponentModel.DataAnnotations;

namespace Lively.Dtos
{
    public class CustomerDto
    {
        public int ID { get; set; }
        //(ErrorMessage = "Please Enter Customer's Name")
        [Required]
        [StringLength(255)]
        public String Name { get; set; }

        public bool IsSubscribedToNewsLetter { get; set; }

        public byte MembershipTypeID { get; set; }

      //  [Min18YearsIfAMember]
        public DateTime? Birthday { get; set; }
    }
}