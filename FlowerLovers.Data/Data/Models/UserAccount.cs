using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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

        [Display(Name = "Image ID")]

        public Image? Image { get; set; }

        [StringLength(BIOGRAPHYMAXLENGTH)]
        public string Biography { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date Of Creation")]
        public DateTime CreationDate { get; set; }

        public IEnumerable<Article> Articles { get; set; } =
            new List<Article>();

        public IEnumerable<Comment> Comments { get; set; } = 
            new List<Comment>();

        //Many-to-Many relationship collections

        public IEnumerable<UserAccount> FollowedUserAccount { get; set; } =
            new List<UserAccount>();

        public IEnumerable<UserAccount> FollowerUserAccount { get; set; } = 
            new List<UserAccount>();
    }
}
