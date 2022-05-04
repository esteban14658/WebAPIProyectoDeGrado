using System.ComponentModel.DataAnnotations;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CreateAddressDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Neighborhood { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string StreetType { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Career { get; set; }
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]
        public string NumberOne { get; set; }
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]
        public string NumberTwo { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Description { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
    }
}
