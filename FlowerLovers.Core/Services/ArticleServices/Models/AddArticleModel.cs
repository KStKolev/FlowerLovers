using FlowerLovers.Core.CustomAttributes.Content;
using FlowerLovers.Core.CustomAttributes.Image;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Data.Data.DataRequirements.ArticleDataConstants;

namespace FlowerLovers.Core.Services.ArticleServices.Models
{
    public class AddArticleModel
    {
        [Required]
        [StringLength(
            TITLEMAXLENGTH,
            MinimumLength = TITLEMINLENGTH)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Image file")]
        [MaxImageResolution(4)]
        [AllowedImageExtensions(new string[] { ".png", ".jpg", ".jpeg" })]
        public IFormFile ImageFile { get; set; } = null!;

        [Required]
        [MaxContentLength(1000)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Date Of Creation")]
        public DateTime CreationDate { get; set; }
    }
}
