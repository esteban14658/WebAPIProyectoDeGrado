using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class ResidenteDTO
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Telefono { get; set; }
        public List<DireccionDTO> ListaDirecciones { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
