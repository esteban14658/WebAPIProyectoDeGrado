using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class ResidenteCreacionDTO
    {
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Telefono { get; set; }
        public List<DireccionCreacionDTO> ListaDirecciones { get; set; }
        public UsuarioCreacionDTO Usuario { get; set; }
    }
}
