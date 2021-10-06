using System.ComponentModel.DataAnnotations;

namespace PG.Bussiness.DTOs.GetDTOs
{
    public class UserCredentials
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
