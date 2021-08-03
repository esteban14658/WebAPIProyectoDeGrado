using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Entitys
{
    public class PuntoDeRecoleccion
    {
        public int Id { get; set; }
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
        public Direccion Direccion { get; set; }
    }
}
