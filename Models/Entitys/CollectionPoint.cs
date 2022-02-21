using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProyectoDeGrado.Entitys
{
    [Table(name: "collection_point")]
    public class CollectionPoint
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Required]
        [Column(name: "create_date")]
        public DateTime CreateDate { get; set; }
        [Column(name: "type_of_material")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string TypeOfMaterial { get; set; }
        [Column(name: "image")]
        [Required(ErrorMessage = "Field {0} is required")]
        public string Image { get; set; }
        [Column(name: "description")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Description { get; set; }
        [Column(name: "state")]
        public string State { get; set; }
        [Required]
        [Column(name: "adress_id")]
        public Address Address { get; set; }
        [Required]
        [Column(name: "resident_id")]
        [ForeignKey("Resident")]
        public int Resident { get; set; }
    }
}
