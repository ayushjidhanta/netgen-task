using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALayer.Models.ModelValidations
{
    public class PhoneNumberAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value is string PhoneNumber)
            {
                if(PhoneNumber.Length == 10 && PhoneNumber.All(char.IsDigit))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("Enter only 10 digits and numeric values only");
        }
    }
}
