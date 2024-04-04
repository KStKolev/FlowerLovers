#nullable disable

using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Web.Areas.Identity.Models
{
    public class DeletePersonalDataInputModel
    {
            [Required]
            [DataType(DataType.Password)]
            public string Password { get; set; }
    }
}
