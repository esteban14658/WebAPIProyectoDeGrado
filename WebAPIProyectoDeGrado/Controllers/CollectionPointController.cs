using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Services;

namespace PG.Presentation.Controllers
{
    [ApiController]
    [Route("api/CollectionPoints")]
    public class CollectionPointController : ControllerBase
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
            return Created("", collectionPoint);
        }

        [HttpGet("GetByEmail/{email}")]
        public async Task<ActionResult<List<CollectionPointDTO>>> GetByEmail(string email)
        {
            var result = await _collectionPoint.GetByEmail(email);
            return Ok(result);
        }
    }
}
