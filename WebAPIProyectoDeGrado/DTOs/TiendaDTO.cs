using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class TiendaDTO
    {
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public DireccionDTO Direccion { get; set; }
        public UsuarioDTO Usuario { get; set; }
    }
}
