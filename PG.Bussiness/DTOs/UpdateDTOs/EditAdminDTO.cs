using System.ComponentModel.DataAnnotations;

namespace PG.Bussiness.DTOs.UpdateDTOs
{
    public class EditAdminDTO
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
