using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DALayer.Models.ModelValidations
{
    public class EmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext? validationContext)
        {
            if (value is string Email)
            {
                if (ValidEmail(Email))
                {
                    return ValidationResult.Success;
                }
            }

            return new ValidationResult("Enter a valid email address such as example@mail.com");
        }

        public bool ValidEmail(string Email)
        {
            var pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
            return Regex.IsMatch(Email, pattern);


        }
    }
}
