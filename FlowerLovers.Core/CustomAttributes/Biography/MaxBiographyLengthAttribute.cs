using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.CustomAttributes.Biography
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter,
    AllowMultiple = false)]
    public class MaxBiographyLengthAttribute : ValidationAttribute
    {
        private readonly int maxBiographyLength;

        public MaxBiographyLengthAttribute(int _maxBiographyLength)
        {
            maxBiographyLength = _maxBiographyLength;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var length = value as string;

            if (length == null) 
            {
                // It can be null.
                return ValidationResult.Success;
            }

            if (length?.Length > maxBiographyLength) 
            {
                return new ValidationResult($"The length has to be less than {maxBiographyLength}");
            }

            return ValidationResult.Success;
        }
    }
}
