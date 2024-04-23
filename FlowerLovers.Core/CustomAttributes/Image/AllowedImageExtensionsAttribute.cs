using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.CustomAttributes.Image
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
     AllowMultiple = false)]
    public class AllowedImageExtensionsAttribute : ValidationAttribute
    {
        private readonly string[] extensions;

        public AllowedImageExtensionsAttribute(string[] _extensions)
        {
            extensions = _extensions;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null) 
            {
                var extension = Path.GetExtension(file.FileName);
                if (!extensions.Contains(extension))
                {
                    return new ValidationResult($"Image allowed extensions are: {string.Join(" ", extensions)}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
