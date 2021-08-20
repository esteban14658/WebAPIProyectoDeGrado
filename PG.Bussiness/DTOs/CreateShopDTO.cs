using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CreateShopDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string DocumentType { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Document { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]

        public string Phone { get; set; }
        public CreateUserDTO User { get; set; }
        public CreateAddressDTO Address { get; set; }
    }
}
