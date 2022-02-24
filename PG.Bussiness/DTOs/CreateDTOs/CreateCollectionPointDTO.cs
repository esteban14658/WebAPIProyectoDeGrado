using Microsoft.AspNetCore.Http;
using PG.Bussiness.Validations;
using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CreateCollectionPointDTO
    {
        [Required]
        public DateTime CreateDate { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string TypeOfMaterial { get; set; }
        [FileSizeWeightValidation(maxWeightOnMB: 4)]
        [TypeOfFileValidation(typeOfFyleGroup:TypeOfFyleGroup.Image)]
        public IFormFile Image { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Description { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Length { get; set; }
        [Required]
        public string Latitude { get; set; }
        [Required]
        public CreateAddressDTO Address { get; set; }
        [Required]
        public int Resident { get; set; }
    }
}
