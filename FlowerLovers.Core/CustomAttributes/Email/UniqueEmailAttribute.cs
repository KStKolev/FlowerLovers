using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.CustomAttributes.Email
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
        AllowMultiple = false)]
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var userManager = validationContext.GetRequiredService<UserManager<ApplicationUser>>();
            var email = value as string;

            if (email == null)
            {
                return new ValidationResult("Email is required.");
            }

            if (email != null && IsAlreadyCreated(email, userManager)) 
            {
                return new ValidationResult("This email is already in use.");
            }

            return ValidationResult.Success;
        }

        private bool IsAlreadyCreated(string email, UserManager<ApplicationUser> userManager) 
        {
            var existingUser = userManager.Users.FirstOrDefault(u => u.Email == email);
            if (existingUser != null) 
            {
                return true;
            }
            return false;
        }
    }
}
