﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CollectionPointDTO
    {
        public DateTime CreateDate { get; set; }
        public string TypeOfMaterial { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Boolean State { get; set; }
        public AddressDTO Address { get; set; }
    }
}