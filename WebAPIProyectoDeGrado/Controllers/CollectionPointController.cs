using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Services;

namespace PG.Presentation.Controllers
{
    [ApiController]
    [Route("api/CollectionPoints")]
    public class CollectionPointController: ControllerBase
    {
        private readonly ICollectionPointService _collectionPoint;

        public CollectionPointController(ICollectionPointService collectionPoint)
        {
            _collectionPoint = collectionPoint;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] CreateCollectionPointDTO createCollectionPointDTO)
        {
            var collectionPoint = await _collectionPoint.Insert(createCollectionPointDTO);
            return Created("",collectionPoint);
        }
    }
}
