using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember :ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customeer) validationContext.ObjectInstance;

            if(customer.MemberShipTypeId ==MemberShipType.Unknown ||
               customer.MemberShipTypeId==MemberShipType.PayAsYouGo)
                return  ValidationResult.Success;

            if (customer.BirthDate == null)
                return new ValidationResult("Please Enter Your Birthdate ");

            var age = DateTime.Today.Year - customer.BirthDate.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be at least 18 years old :");
        }
    }
}