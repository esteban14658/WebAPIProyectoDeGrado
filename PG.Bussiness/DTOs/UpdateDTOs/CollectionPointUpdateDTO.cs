using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PG.Bussiness.DTOs.UpdateDTOs
{
    public class CollectionPointUpdateDTO
    {
        public int Id { get; set; }
        public string TypeOfMaterial { get; set; }
        public string State { get; set; }
        public int RouteId { get; set; }
    }
}
