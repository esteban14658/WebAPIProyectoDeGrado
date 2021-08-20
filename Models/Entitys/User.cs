using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Entitys
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 12, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        [PasswordPropertyText]
        public string Password { get; set; }
        [Required]
        public Boolean Estado { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 12, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Rol { get; set; }
    }
}
