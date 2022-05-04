using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CreateUserDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 50, ErrorMessage = "field {0} must be less than {1} characters")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 40, ErrorMessage = "field {0} must be less than {1} characters")]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        public Boolean State { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 15, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Role { get; set; }
    }
}
