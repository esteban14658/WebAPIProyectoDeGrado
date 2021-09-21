using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.Entitys
{
    [Table(name:"adress")]
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
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]
        public string NumberOne { get; set; }
        [Column(name: "number_two")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]
        public string NumberTwo { get; set; }
        [Column(name: "description")]
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Description { get; set; }
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
