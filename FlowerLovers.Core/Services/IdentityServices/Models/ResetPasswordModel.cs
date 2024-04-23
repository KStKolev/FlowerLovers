using FlowerLovers.Core.CustomAttributes.Email;
using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Core.Services.IdentityServices.Models.DataRequirements.ResetPasswordInputDataConstants;

namespace FlowerLovers.Core.Services.IdentityServices.Models
{
    public class ResetPasswordModel
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        [EmailValidation]
        [EmailNotCreated]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(
            PASSWORDMAXLENGTH,
            ErrorMessage = PASSWORDERRORMESSAGE,
            MinimumLength = PASSWORDMINLENGTH
        )]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = CONFIRMPASSWORDERRORMESSAGE)]
        public string ConfirmPassword { get; set; } = string.Empty;

        [Required]
        public string Token { get; set; } = string.Empty;
    }
}
