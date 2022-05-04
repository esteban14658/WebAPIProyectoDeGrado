using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CreateResidentDto
    {
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 25, ErrorMessage = "field {0} must be less than {1} characters")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Field {0} is required")]
        [StringLength(maximumLength: 10, ErrorMessage = "field {0} must be less than {1} characters")]
        public string Phone { get; set; }
        public List<CreateAddressDto> AddressList { get; set; }
        public CreateUserDto User { get; set; }
    }
}
