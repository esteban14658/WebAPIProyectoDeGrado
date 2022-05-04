using System.Collections.Generic;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class ResidentDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<AddressDto> AddressList { get; set; }
        public UserDto User { get; set; }
    }
}
