using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace FlowerLovers.Core.CustomAttributes.Email
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class EmailValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var email = value as string;

            if (email != null && !IsValid(email))
            {
                return new ValidationResult("Invalid email address.");
            }

            return ValidationResult.Success;
        }

        private bool IsValid(string email) 
        {
            // Regex pattern for validation
            string pattern = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";

            Regex regex = new Regex(pattern);

            return regex.IsMatch(email);
        }
    }
}
