using System;
using System.Collections.Generic;
using WebAPIProyectoDeGrado.DTOs;

namespace PG.Bussiness.DTOs.CreateDTOs
{
    public class CreateRouteDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<CreateCollectionPointDTO> CollectionPoints { get; set; }
        public CreateCommentDTO Comment { get; set; }
        public CreateRecyclerDTO Recycler { get; set; }
    }
}
