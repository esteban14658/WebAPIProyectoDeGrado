using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
using PG.Presentation.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Services;

namespace PG.Presentation.Controllers
{
    [ApiController]
    [Route("api/CollectionPoints")]
    public class CollectionPointController : ControllerBase
    {
        private readonly ICollectionPointService _collectionPoint;
        private readonly IImageStorage imageStorage;
        private readonly IMapper mapper;
        private readonly string container = "collectionPoints";
        private readonly ApplicationDbContext _context;

        public CollectionPointController(ICollectionPointService collectionPoint, IImageStorage imageStorage,
            IMapper mapper, ApplicationDbContext context)
        {
            _collectionPoint = collectionPoint;
            this.imageStorage = imageStorage;
            this.mapper = mapper;
            _context = context;
        }

        [HttpPost("{extension}")]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromBody] CreateCollectionPointDto createCollectionPointDTO, string extension)
        {
            var resident = await _context.Residents.FindAsync(createCollectionPointDTO.Resident);

            if (resident == null)
            {
                return BadRequest();
            }
            var call = _collectionPoint.Base64ToIFormFile(createCollectionPointDTO.Image);
            createCollectionPointDTO.CommentState = false;
            var date = DateTime.Now.ToUniversalTime().AddHours(-5);
            var collectionPoint = mapper.Map<CollectionPoint>(createCollectionPointDTO);
            collectionPoint.CreateDate = date;
            if (createCollectionPointDTO.Image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await call.CopyToAsync(memoryStream);
                    var contents = memoryStream.ToArray();
                    collectionPoint.Image = await imageStorage.SaveFile(contents, "." + extension, container,
                        "image/" + extension);
                }
            }
            _context.Add(collectionPoint);
            await _context.SaveChangesAsync();
            var result = mapper.Map<CollectionPointDto>(collectionPoint);
            return Created("", result);
        }

        [HttpGet("{page:int}/{amount:int}")]
        public async Task<ActionResult<PaginateDto<CollectionPointDto>>> Get(int page, int amount)
        {
            var collectionPoint = await _collectionPoint.GetAll(page, amount);
            return Ok(collectionPoint);
        }

        [HttpGet("GetByState/{page:int}/{amount:int}/{state}")]
        public async Task<ActionResult<PaginateDto<CollectionPointDto>>> GetByState(int page, int amount, string state)
        {
            var collectionPoint = await _collectionPoint.GetByState(page, amount, state);
            return Ok(collectionPoint);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<CollectionPointDto>> GetById(int id)
        {
            var collectionPoint = await _collectionPoint.GetById(id);
            return Ok(collectionPoint);
        }

        [HttpGet("GetByTypeOfMaterial/{page:int}/{amount:int}/{typeOfMaterial}")]
        public async Task<ActionResult<PaginateDto<CollectionPointDto>>> GetByTypeOfMaterial(int page, int amount, string typeOfMaterial)
        {
            var collectionPoint = await _collectionPoint.GetByTypeOfMaterial(page, amount, typeOfMaterial);
            return Ok(collectionPoint);
        }

        [HttpGet("GetByDate/{page:int}/{amount:int}")]
        public async Task<ActionResult<PaginateDto<CollectionPointDto>>> GetByDate(int page, int amount)
        {
            var collectionPoint = await _collectionPoint.GetByDate(page, amount);
            return Ok(collectionPoint);
        }

        [HttpGet("{date}")]
        public async Task<ActionResult<List<CollectionPointDto>>> GetByDate(string date)
        {
            var points = await _collectionPoint.GetByDate(date);
            return Ok(points);
        }

        [HttpGet("GetByStateAndType/{page:int}/{amount:int}/{state}/{type}")]
        public async Task<ActionResult<PaginateDto<CollectionPointDto>>> GetByStateAndType(int page, int amount, string state, string type)
        {
            var collectionPoint = await _collectionPoint.GetByStateAndType(page, amount, state, type);
            return Ok(collectionPoint);
        }

        [HttpGet("GetByIdResident/{page:int}/{amount:int}/{idResident:int}/{state}")]
        public async Task<ActionResult<PaginateDto<CollectionPointDto>>> GetByIdResident(int page, int amount, int idResident, string state)
        {
            var collectionPoint = await _collectionPoint.GetByIdResident(page, amount, idResident, state);
            return Ok(collectionPoint);
        }

        [HttpGet("GetByIdRoute/{page:int}/{amount:int}/{idRoute:int}/{state}")]
        public async Task<ActionResult<PaginateDto<CollectionPointDto>>> GetByIdRoute(int page, int amount, int idRoute, string state)
        {
            var collectionPoint = await _collectionPoint.GetByIdRoute(page, amount, idRoute, state);
            return Ok(collectionPoint);
        }

        [HttpPut("AssignToRoute/{stateCompare}")]
        public async Task<ActionResult<int>> AssignToRoute([FromBody] CollectionPointUpdateDto dto, string stateCompare)
        {
            await _collectionPoint.AssignToRoute(dto, stateCompare);
            return Ok();
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _collectionPoint.Delete(id);
            return NoContent();
        }
    }
}
