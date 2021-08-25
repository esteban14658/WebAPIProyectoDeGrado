using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPIProyectoDeGrado.DTOs
{
    public class RecyclerDTO
    {
        public string Name { get; set; }
        public string LastName { get; set; }
        public string DocumentType { get; set; }
        public string Document { get; set; }
        public string Phone { get; set; }
        public UserDTO User { get; set; }
    }
}
