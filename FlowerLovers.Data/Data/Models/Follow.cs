using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace FlowerLovers.Data.Data.Models
{
    public class Follow
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Follower User Account ID")]
        public int FollowerUserAccountId { get; set; }

        [Required]
        [Display(Name = "Followed User Acccount ID")]
        public int FollowedUserAccountId { get; set; }

        [Required]
        [Display(Name = "Date Of Follow")]
        public DateTime DateOfFollow { get; set; }
    }
}
