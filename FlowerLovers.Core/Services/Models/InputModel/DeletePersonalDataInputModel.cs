#nullable disable

using System.ComponentModel.DataAnnotations;

namespace FlowerLovers.Core.Services.Models.InputModel
{
    public class DeletePersonalDataInputModel
    {
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
