using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Data.Data.DataRequirements.UserAccountDataConstants;

namespace FlowerLovers.Data.Data.Models
{
    public class UserAccount
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(
            USERNAMEMAXLENGTH, 
            MinimumLength = USERNAMEMINLENGTH)]
        public string Username { get; set; } = string.Empty;

        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [StringLength(BIOGRAPHYMAXLENGTH)]
        public string Biography { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date Of Creation")]
        public DateTime CreationDate { get; set; }

        public IEnumerable<Article> Articles { get; set; } =
            new List<Article>();
    }
}
