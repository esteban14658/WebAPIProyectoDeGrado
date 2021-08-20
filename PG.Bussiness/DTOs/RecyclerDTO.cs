using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class RecyclerDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string TipoDeDocumento { get; set; }
        public string Documento { get; set; }
        public string Telefono { get; set; }
        public UserDTO Usuario { get; set; }
    }
}
