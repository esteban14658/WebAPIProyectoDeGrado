using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 15, ErrorMessage = "field {0} must be less than {1} characters")]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        public Boolean State { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 15, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Role { get; set; }
    }
}
