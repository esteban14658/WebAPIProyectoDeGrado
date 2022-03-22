using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPIProyectoDeGrado.Entitys
{
    [Table(name: "address")]
    public class Address
    {
        [Column(name: "id")]
        public int Id { get; set; }
        [Column(name: "neighborhood")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Neighborhood { get; set; }
        [Column(name: "street_type")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string StreetType { get; set; }
        [Column(name: "career")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Career { get; set; }
        [Column(name: "number_one")]
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]
        public string NumberOne { get; set; }
        [Column(name: "number_two")]
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]
        public string NumberTwo { get; set; }
        [Column(name: "description")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Description { get; set; }
        [Required]
        [Column(name: "longitude")]
        public double? Longitude { get; set; }
        [Required]
        [Column(name: "latitude")]
        public double? Latitude { get; set; }
        [Column(name: "resident_id")]
        public Resident Resident { get; set; }
        [Column(name: "shop_id")]
        [ForeignKey("Shop")]
        public int? ShopId { get; set; }
        [Column(name: "collection_point_id")]
        [ForeignKey("CollectionPoint")]
        public int? CollectionPointId { get; set; }
    }
}
