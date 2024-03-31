using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Data.Data.DataRequirements.TagDataConstants;

namespace FlowerLovers.Data.Data.Models
{
    public class Tag
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(
            NAMEMAXLENGTH, 
            MinimumLength = NAMEMINLENGTH)]
        public string Name { get; set; } = string.Empty;

        public IEnumerable<ArticleTag> ArticlesTags { get; set; } = 
            new List<ArticleTag>();
    }
}
