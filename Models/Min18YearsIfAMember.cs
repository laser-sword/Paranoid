using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Paranoid.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == 0 || customer.MemberShipTypeId == 1) 
                return ValidationResult.Success;

            if (customer.DOB == null) 
                return new ValidationResult("Birthday is required!");

            var age = DateTime.Today.Year - customer.DOB.Year;

                    return (age >= 18) 
                        ? ValidationResult.Success 
                        : new ValidationResult("Customer should be 18 years of age. ");
                
        }
    }


}
