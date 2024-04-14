using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Core.Services.Models.InputModel.DataRequirements.RegisterInputDataConstants;
using static FlowerLovers.Data.Data.DataRequirements.ApplicationUserDataConstants;


namespace FlowerLovers.Core.Services.Models
{
    public class RegisterModel
    {

        [Required]
        [StringLength(
            FIRSTNAMEMAXLENGTH,
            ErrorMessage = PROPERTIESERRORMESSAGE,
            MinimumLength = FIRSTNAMEMINLENGTH
        )]
        [Display(Name = "First name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(
        LASTNAMEMAXLENGTH,
        ErrorMessage = PROPERTIESERRORMESSAGE,
        MinimumLength = LASTNAMEMINLENGTH
        )]
        [Display(Name = "Last name")]
        public string LastName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; } = string.Empty;

        [Required]
        [StringLength(
        PASSWORDMAXLENGTH,
        ErrorMessage = PROPERTIESERRORMESSAGE,
        MinimumLength = PASSWORDMINLENGTH
        )]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; } = string.Empty;

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = CONFIRMPASSWORDERRORMESSAGE)]
        public string ConfirmPassword { get; set; } = string.Empty;
    }
}
