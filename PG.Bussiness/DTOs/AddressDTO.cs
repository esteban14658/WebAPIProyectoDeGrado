using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Barrio { get; set; }
        public string TipoDeCalle { get; set; }
        public string Carrera { get; set; }
        public string Numero1 { get; set; }
        public string Numero2 { get; set; }
        public string Descripcion { get; set; }
    }
}
