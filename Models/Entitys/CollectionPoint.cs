using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Entitys
{
    public class CollectionPoint
    {
        public int Id { get; set; }
        [Required]
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 20, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string TypeOfMaterial { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Image { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, ErrorMessage = "El campo {0} debe ser menor a {1} caracteres")]
        public string Description { get; set; }
        public Boolean State { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}
