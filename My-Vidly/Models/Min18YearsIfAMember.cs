using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace My_Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer) validationContext.ObjectInstance;

            if (customer.MembershipTypeId == Customer.Unknown || customer.MembershipTypeId == Customer.PayasYouGo)
            { 
                return ValidationResult.Success;
            }

            if (customer.DOB == null)
            {
                return new ValidationResult("Birthdate is Required.");
            }

                var age = DateTime.Today.Year - customer.DOB.Value.Year;
                return (age >= 18) ? ValidationResult.Success : new ValidationResult("Customer should be above 18.");
        
        }
    }
}