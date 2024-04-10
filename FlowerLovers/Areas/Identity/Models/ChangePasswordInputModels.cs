#nullable disable

using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Web.Areas.Identity.DataRequirements.ChangePasswordInputDataConstants;

namespace FlowerLovers.Web.Areas.Identity.Models
{
    public class ChangePasswordInputModels
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(PASSWORDMAXLENGTH, ErrorMessage = PASSWORDERRORMESSAGE, MinimumLength = PASSWORDMINLENGTH)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = CONFIRMEDPASSWORDERRORMESSAGE)]
        public string ConfirmPassword { get; set; }
    }
}
