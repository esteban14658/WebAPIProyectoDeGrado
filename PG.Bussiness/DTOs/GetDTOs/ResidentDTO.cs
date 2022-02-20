﻿using System.Collections.Generic;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class ResidentDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<AddressDTO> AddressList { get; set; }
        public UserDTO User { get; set; }
    }
}