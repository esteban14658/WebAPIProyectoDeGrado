using System.ComponentModel.DataAnnotations;

namespace PG.Bussiness.DTOs.UpdateDTOs
{
    public class EditAdminDto
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
