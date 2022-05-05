using PG.Bussiness.DTOs.CreateDTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CreateShopDto
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
        public List<CreateOrderDto> OrderList { get; set; }
        public CreateUserDto User { get; set; }
        public CreateAddressDto Address { get; set; }
    }
}
