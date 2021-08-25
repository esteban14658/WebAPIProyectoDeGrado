using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string Neighborhood { get; set; }
        public string StreetType { get; set; }
        public string Career { get; set; }
        public string NumberOne { get; set; }
        public string NumberTwo { get; set; }
        public string Description { get; set; }
    }
}
