using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CreateCollectionPoint
    {
        [Required]
        public DateTime FechaCreacion { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string TipoDeMaterial { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Imagen { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Descripcion { get; set; }
        public Boolean Estado { get; set; }
        [Required]
        public CreateAddressDTO Direccion { get; set; }
    }
}
