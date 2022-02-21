using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs;
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

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromForm] CreateCollectionPointDTO createCollectionPointDTO)
        {
            var resident = await _context.Residents.FindAsync(createCollectionPointDTO.Resident);

            if (resident == null)
            {
                return BadRequest();
            }

            DateTime date = DateTime.Now;
            createCollectionPointDTO.CreateDate = date;
            var collectionPoint = mapper.Map<CollectionPoint>(createCollectionPointDTO);

            if (createCollectionPointDTO.Image != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await createCollectionPointDTO.Image.CopyToAsync(memoryStream);
                    var contents = memoryStream.ToArray();
                    var extension = Path.GetExtension(createCollectionPointDTO.Image.FileName);
                    collectionPoint.Image = await imageStorage.SaveFile(contents, extension, container,
                        createCollectionPointDTO.Image.ContentType);
                }
            }
            _context.Add(collectionPoint);
            await _context.SaveChangesAsync();
            var result = mapper.Map<CollectionPointDTO>(collectionPoint);
            return Created("", result);
        }

        [HttpGet("{page:int}/{amount:int}")]
        public async Task<ActionResult<PaginateDTO<CollectionPointDTO>>> Get(int page, int amount)
        {
            var collectionPoint = await _collectionPoint.GetAll(page, amount);
            return Ok(collectionPoint);
        }
    }
}
