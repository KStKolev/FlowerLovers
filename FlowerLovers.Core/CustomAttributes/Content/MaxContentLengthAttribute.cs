using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.CustomAttributes.Content
{
    public class MaxContentLengthAttribute : ValidationAttribute
    {
        private readonly int maxContentLength;

        public MaxContentLengthAttribute(int _maxContentLength)
        {
            maxContentLength = _maxContentLength;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var length = value as string;

            if (length == null)
            {
                return new ValidationResult($"The length cannot be empty.");
            }

            if (length?.Length > maxContentLength)
            {
                return new ValidationResult($"The length has to be less than {maxContentLength}");
            }

            return ValidationResult.Success;
        }
    }
}
