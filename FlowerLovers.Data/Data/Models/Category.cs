using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Data.Data.DataRequirements.CategoryDataConstants;

namespace FlowerLovers.Data.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; init; }

        [Required]
        [StringLength(NAMEMAXLENGTH)]
        public string Name { get; init; } = string.Empty;
    }
}
