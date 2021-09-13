using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public Boolean State { get; set; }
        public string Role { get; set; }
    }
}
