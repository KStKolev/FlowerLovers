using FlowerLovers.Data.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.CustomAttributes.Email
{
    public class EmailNotCreatedAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var userManager = validationContext.GetRequiredService<UserManager<ApplicationUser>>();
            var email = value as string;

            if (email != null && !IsAlreadyCreated(email, userManager))
            {
                return new ValidationResult("This email is not created.");
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
