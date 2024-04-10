#nullable disable
using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Data.Data.DataRequirements.ApplicationUserDataConstants;
using static FlowerLovers.Web.Areas.Identity.DataRequirements.RegisterInputDataConstants;

namespace FlowerLovers.Web.Areas.Identity.Models
{
    public class RegisterInputModel
    {
            [Required]
            [StringLength(
                FIRSTNAMEMAXLENGTH, 
                ErrorMessage = PROPERTIESERRORMESSAGE, 
                MinimumLength = FIRSTNAMEMINLENGTH
            )]
            [Display(Name = "First name")]
            public string FirstName { get; set; }

            [Required]
            [StringLength(
            LASTNAMEMAXLENGTH, 
            ErrorMessage = PROPERTIESERRORMESSAGE, 
            MinimumLength = LASTNAMEMINLENGTH
            )]
            [Display(Name = "Last name")]
            public string LastName { get; set; }
            
            [Required]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required]
            [StringLength(
            PASSWORDMAXLENGTH, 
            ErrorMessage = PROPERTIESERRORMESSAGE, 
            MinimumLength = PASSWORDMINLENGTH
            )]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = CONFIRMPASSWORDERRORMESSAGE)]
            public string ConfirmPassword { get; set; }
    }
}
