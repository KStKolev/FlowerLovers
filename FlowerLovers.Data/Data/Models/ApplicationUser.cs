using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Data.Data.DataRequirements.ApplicationUserDataConstants;

namespace FlowerLovers.Data.Data.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [StringLength(
            FIRSTNAMEMAXLENGTH,
            MinimumLength = FIRSTNAMEMINLENGTH
            )]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [StringLength(
            LASTNAMEMAXLENGTH,
            MinimumLength = LASTNAMEMINLENGTH
            )]
        public string LastName { get; set; } = string.Empty;
    }   
}
