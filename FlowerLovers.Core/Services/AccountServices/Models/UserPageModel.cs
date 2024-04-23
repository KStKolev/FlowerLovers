using FlowerLovers.Data.Data.Models;
using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Data.Data.DataRequirements.UserAccountDataConstants;

namespace FlowerLovers.Core.Services.AccountServices.Models
{
    public class UserPageModel
    {
        [Required]
        [StringLength(
        USERNAMEMAXLENGTH,
        MinimumLength = USERNAMEMINLENGTH)]
        public string Username { get; set; } = string.Empty;

        public Image? Image { get; set; } = null!;

        [StringLength(BIOGRAPHYMAXLENGTH)]
        public string Biography { get; set; } = string.Empty;
        public int Followers { get; set; }
        public int Articles { get; set; }
        public DateTime DataOfCreation { get; set; }
    }
}
