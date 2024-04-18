using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.Services.Models
{
    public class ForgotPasswordModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }  = string.Empty;
    }
}
