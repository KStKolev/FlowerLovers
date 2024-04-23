using FlowerLovers.Core.CustomAttributes.Email;
using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.Services.IdentityServices.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [EmailValidation]
        [EmailNotCreated]
        public string Email { get; set; } = string.Empty;
    }
}
