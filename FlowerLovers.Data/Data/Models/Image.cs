using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerLovers.Data.Data.DataRequirements.ImageDataConstants;

namespace FlowerLovers.Data.Data.Models
{
    public class Image
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Image Path")]
        public string ImagePath { get; set; } = string.Empty;

        [Required]
        [StringLength(CAPTIONMAXLENGTH)]
        public string Caption { get; set; } = string.Empty;

        public int UserAccountId { get; set; }
        [ForeignKey(nameof(UserAccountId))]
        public UserAccount? UserAccount { get; set; }

        public int ArticleId { get; set; }
        [ForeignKey(nameof(ArticleId))]
        public Article? Article { get; set; }
    }
}
