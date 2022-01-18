using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProyectoDeGrado.Entitys
{
    [Table(name: "user")]
    public class User
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "email")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        [EmailAddress]
        public string Email { get; set; }
        [Column(name: "password")]
        
        [Required(ErrorMessage = "Field {0} is required")]
        //[StringLength(maximumLength: 40, ErrorMessage = "field {0} must be less than {1} characters")]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        [Column(name: "state")]
        public Boolean State { get; set; }
        [Column(name: "role")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 15, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Role { get; set; }
    }
}
