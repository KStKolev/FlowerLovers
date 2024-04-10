#nullable disable
using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Web.Areas.Identity.DataRequirements.ResetPasswordInputDataConstants;

namespace FlowerLovers.Web.Areas.Identity.Models
{
    public class ResetPasswordInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(
            PASSWORDMAXLENGTH, 
            ErrorMessage = PASSWORDERRORMESSAGE, 
            MinimumLength = PASSWORDMINLENGTH
        )]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = CONFIRMPASSWORDERRORMESSAGE)]
        public string ConfirmPassword { get; set; }

        [Required]
        public string Code { get; set; }
    }
}
