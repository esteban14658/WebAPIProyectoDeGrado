﻿using System;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class CollectionPointDTO
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string TypeOfMaterial { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public Boolean State { get; set; }
        public AddressDTO Address { get; set; }
        public int User { get; set; }
    }
}
