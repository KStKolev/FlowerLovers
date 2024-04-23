using FlowerLovers.Core.CustomAttributes.Category;
using FlowerLovers.Core.CustomAttributes.Content;
using FlowerLovers.Core.CustomAttributes.Image;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using static FlowerLovers.Data.Data.DataRequirements.ArticleDataConstants;

namespace FlowerLovers.Core.Services.ArticleServices.Models
{
    public class EditArticleModel
    {
        public int ArticleId { get; set; }

        [StringLength(
            TITLEMAXLENGTH,
            MinimumLength = TITLEMINLENGTH)]
        public string Title { get; set; } = string.Empty;

        public string ImageUrl { get; set; } = string.Empty;

        [MaxContentLength(1000)]
        public string Content { get; set; } = string.Empty;

        [CategoryName]
        public string Category { get; set; } = string.Empty;

        public int CategoryId { get; set; }

        [Display(Name = "Image file")]
        [MaxImageResolution(4)]
        [AllowedImageExtensions(new string[] { ".png", ".jpg", ".jpeg" })]
        public IFormFile? ImageFile { get; set; } = null!;
    }
}
