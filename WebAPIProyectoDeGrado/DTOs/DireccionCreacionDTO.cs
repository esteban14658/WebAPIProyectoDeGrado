using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class DireccionCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Barrio { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string TipoDeCalle { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 5, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Carrera { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 5, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Numero1 { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 5, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Numero2 { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Descripcion { get; set; }
    }
}
