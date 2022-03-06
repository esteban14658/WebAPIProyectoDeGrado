using Microsoft.AspNetCore.Http;
using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.Validations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CreateShopDTO
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 15, ErrorMessage = "field {0} must be less than {1} characters")]
        public string DocumentType { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Document { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]

        public string Phone { get; set; }
        [FileSizeWeightValidation(maxWeightOnMB: 4)]
        [TypeOfFileValidation(typeOfFyleGroup: TypeOfFyleGroup.Image)]
        public IFormFile Image { get; set; }
        public List<CreateOrderDTO> OrderList { get; set; }
        public CreateUserDTO User { get; set; }
        public CreateAddressDTO Address { get; set; }
    }
}
