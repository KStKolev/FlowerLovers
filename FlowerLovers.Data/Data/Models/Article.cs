using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static FlowerLovers.Data.Data.DataRequirements.ArticleDataConstants;

namespace FlowerLovers.Data.Data.Models
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(
            TITLEMAXLENGTH, 
            MinimumLength = TITLEMINLENGTH)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(
            CONTENTMAXLENGTH, 
            MinimumLength = CONTENTMINLENGTH)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Display(Name = "User Account ID")]
        public int UserAccountId { get; set; }
        [ForeignKey(nameof(UserAccountId))]
        public UserAccount UserAccount { get; set; } = null!;

        [Required]
        [Display(Name = "Date Of Publish")]
        public DateTime DateOfPublish { get; set; }

        [Required]
        [Display(Name = "Category ID")]
        public int CategoryId { get; set; }
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Display(Name = "Image URL")]

        public string ImageUrl { get; set; } = string.Empty;

        public List<Rate> Rates { get; set; } = 
            new List<Rate>();
    }
}
