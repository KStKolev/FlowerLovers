using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.CustomAttributes.Image
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
     AllowMultiple = false)]
    public class MaxImageResolutionAttribute : ValidationAttribute
    {
        private readonly int maxSize;

        public MaxImageResolutionAttribute(int _maxSize) 
        {
            maxSize = _maxSize;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;
            if (file != null) 
            {
                if (file.Length > (1000000 * maxSize))
                {
                    return new ValidationResult($"Maximum allowed file size is {maxSize} MB.");
                }
            }
            return ValidationResult.Success;
        }
    }
}
