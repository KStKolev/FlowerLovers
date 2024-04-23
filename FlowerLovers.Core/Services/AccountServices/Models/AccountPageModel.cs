using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Data.Data.DataRequirements.UserAccountDataConstants;

namespace FlowerLovers.Core.Services.AccountServices.Models
{
    public class AccountPageModel
    {
        [Required]
        [StringLength(
        USERNAMEMAXLENGTH,
        MinimumLength = USERNAMEMINLENGTH)]
        public string Username { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;
        public string Biography { get; set; } = string.Empty;
        public int Followers { get; set; }
        public int Articles { get; set; }

        [Display(Name = "Date Of Creation")]
        public DateTime DateOfCreation { get; set; }
    }
}
