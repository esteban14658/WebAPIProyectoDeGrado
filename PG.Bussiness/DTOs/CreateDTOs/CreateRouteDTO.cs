using PG.Bussiness.DTOs.UpdateDTOs;
using System;
using System.Collections.Generic;
using WebAPIProyectoDeGrado.DTOs;

namespace PG.Bussiness.DTOs.CreateDTOs
{
    public class CreateRouteDTO
    {
        public CreateCommentDTO Comment { get; set; }
        public int Recycler { get; set; }
    }
}
