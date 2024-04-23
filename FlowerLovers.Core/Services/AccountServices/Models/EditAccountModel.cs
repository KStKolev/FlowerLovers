using FlowerLovers.Core.CustomAttributes.Biography;
using FlowerLovers.Core.CustomAttributes.Image;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.Services.AccountServices.Models
{
    public class EditAccountModel
    {
        [Display(Name = "Image File")]
        [MaxImageResolution(4)]
        [AllowedImageExtensions(new string[] { ".jpg", ".png", ".jpeg" })]
        public IFormFile? ImageFile { get; set; }

        [MaxBiographyLength(300)]
        public string Biography { get; set; } = string.Empty;
    }
}
