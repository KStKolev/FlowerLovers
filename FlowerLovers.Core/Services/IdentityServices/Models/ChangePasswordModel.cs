using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Core.Services.IdentityServices.Models.DataRequirements.ChangePasswordInputDataConstants;

namespace FlowerLovers.Core.Services.IdentityServices.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; } = string.Empty;

        [Required]
        [StringLength(PASSWORDMAXLENGTH, ErrorMessage = PASSWORDERRORMESSAGE, MinimumLength = PASSWORDMINLENGTH)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = CONFIRMEDPASSWORDERRORMESSAGE)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
