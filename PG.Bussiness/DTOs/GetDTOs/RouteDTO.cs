using System;
using System.Collections.Generic;
using WebAPIProyectoDeGrado.DTOs;

namespace PG.Bussiness.DTOs.GetDTOs
{
    public class RouteDto
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<CollectionPointDto> CollectionPoints { get; set; }
        public CommentDto Comment { get; set; }
        public int Recycler { get; set; }
    }
}
