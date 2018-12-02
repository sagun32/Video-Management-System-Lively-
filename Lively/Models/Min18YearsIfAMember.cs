using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lively.Models
{
    public class Min18YearsIfAMember:ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MembershipTypeID==MembershipType.Unknown 
                || customer.MembershipTypeID==MembershipType.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthday == null)
                return new ValidationResult("Birthdate is Required");

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;
            return (age >=18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be ateast 18 years old to go on a Membership.");
        }
    }
}