using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.Services.Models
{
    public class DeletePersonalDataModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Require Password")]
        public bool RequirePassword { get; set; }
    }
}
