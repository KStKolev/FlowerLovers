using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.CustomAttributes.Category
{
    public class CategoryNameAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string[] categoryArray = new string[] 
            {
                "Amusement",
                "Educational",
                "Appeal"
            };

            var categoryName = value as string;

            if (categoryName == null) 
            {
                return new ValidationResult("The category cannot be null.");
            }

            if (!categoryArray.Contains(categoryName))
            {
                return new ValidationResult($"The category cannot be named {categoryName}");
            }

            return ValidationResult.Success;
        }
    }
}
