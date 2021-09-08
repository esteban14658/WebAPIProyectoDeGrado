using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class ShopDTO
    {
        public string Name { get; set; }
        public string Telefono { get; set; }
        public string DocumentType { get; set; }
        public string Document { get; set; }
        public AddressDTO Address { get; set; }
        public UserDTO User { get; set; }
    }
}
