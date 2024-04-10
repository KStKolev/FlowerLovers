#nullable disable

using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Web.Areas.Identity.DataRequirements.SetPasswordInputDataConstants;

namespace FlowerLovers.Web.Areas.Identity.Models
{
    public class SetPasswordInputModel
    {
        [Required]
        [StringLength(PASSWORDMAXLENGTH, ErrorMessage = PASSWORDERRORMESSAGE, MinimumLength = PASSWORDMINLENGTH)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [Compare("NewPassword", ErrorMessage = CONFIRMPASSWORDERRORMESSAGE)]
        public string ConfirmPassword { get; set; }
    }
}
