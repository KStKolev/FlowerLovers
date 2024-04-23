using FlowerLovers.Core.CustomAttributes.Email;
using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.Services.IdentityServices.Models
{
    public class LogInModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [EmailValidation]
        [EmailNotCreated]
        public string Email { get; set; } = string.Empty;

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
