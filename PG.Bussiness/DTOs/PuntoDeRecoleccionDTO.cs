using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class PuntoDeRecoleccionDTO
    {
        public DateTime FechaCreacion { get; set; }
        public string TipoDeMaterial { get; set; }
        public string Imagen { get; set; }
        public string Descripcion { get; set; }
        public Boolean Estado { get; set; }
        public DireccionDTO Direccion { get; set; }
    }
}
