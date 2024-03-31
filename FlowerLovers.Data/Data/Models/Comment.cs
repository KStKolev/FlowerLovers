using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerLovers.Data.Data.DataRequirements.CommentDataConstants;

namespace FlowerLovers.Data.Data.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Article ID")]
        public int ArticleId { get; set; }
        [ForeignKey(nameof(ArticleId))]
        public Article Article { get; set; } = null!;

        [Required]
        [Display(Name = "User Account ID")]
        public int UserAccountId { get; set; }
        [ForeignKey(nameof(UserAccountId))]
        public UserAccount UserAccount { get; set; } = null!;

        [Required]
        [StringLength(CONTENTMAXLENGTH)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date Of Post")]
        public DateTime DateOfPost { get; set; }
    }
}
