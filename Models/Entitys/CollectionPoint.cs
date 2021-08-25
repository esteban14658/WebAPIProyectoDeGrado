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
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string TypeOfMaterial { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 35, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Image { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Description { get; set; }
        public Boolean State { get; set; }
        [Required]
        public Address Address { get; set; }
    }
}
