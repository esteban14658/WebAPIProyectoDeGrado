using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class ShopDTO
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string TipoDeDocumento { get; set; }
        public string Documento { get; set; }
        public AddressDTO Direccion { get; set; }
        public UserDTO Usuario { get; set; }
    }
}
