using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;

namespace PG.Bussiness.DTOs.GetDTOs
{
    public class RouteDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<CollectionPointDTO> CollectionPoints { get; set; }
        public CommentDTO Comment { get; set; }
        public RecyclerDTO Recycler { get; set; }
    }
}
