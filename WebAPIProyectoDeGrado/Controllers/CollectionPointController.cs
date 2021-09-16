using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;

namespace PG.Presentation.Controllers
{
    [ApiController]
    [Route("api/CollectionPoints")]
    public class CollectionPointController: ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IMapper mapper;

        public CollectionPointController(ApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCollectionPointDTO createCollectionPointDTO)
        {
            DateTime date = DateTime.Now;
            createCollectionPointDTO.CreateDate = date;
            var collectionPoint = mapper.Map<CollectionPoint>(createCollectionPointDTO);

            context.Add(collectionPoint);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
