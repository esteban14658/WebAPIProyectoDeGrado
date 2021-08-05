using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Entitys
{
    public class Direccion
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Barrio { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 25, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Descripcion { get; set; }
        public int? ResidenteId { get; set; }
        [ForeignKey("Tienda")]
        public int? TiendaId { get; set; }
        [ForeignKey("PuntoDeRecoleccion")]
        public int? PuntoDeRecoleccionId { get; set; }
    }
}
