#nullable disable

using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Web.Areas.Identity.Models
{
    public class ForgotPasswordInputModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
