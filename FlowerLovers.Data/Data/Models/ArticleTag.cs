using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FlowerLovers.Data.Data.Models
{
    public class ArticleTag
    {
        [Required]
        [Display(Name = "Article ID")]
        public int ArticleId { get; set; }
        [ForeignKey(nameof(ArticleId))]
        public Article Article { get; set; } = null!;

        [Required]
        [Display(Name = "Tag ID")]
        public int TagId { get; set; }
        [ForeignKey(nameof(TagId))]
        public Tag Tag { get; set; } = null!;

    }
}
