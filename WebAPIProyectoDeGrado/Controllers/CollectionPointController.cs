using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PG.Presentation.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
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

        public CollectionPointController(ICollectionPointService collectionPoint, IImageStorage imageStorage,
            IMapper mapper)
        {
            _collectionPoint = collectionPoint;
            this.imageStorage = imageStorage;
            this.mapper = mapper;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Post([FromForm] CreateCollectionPointDTO createCollectionPointDTO)
        {
            DateTime date = DateTime.Now;
            createCollectionPointDTO.CreateDate = date;
            createCollectionPointDTO.State = false;
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
            var result = await _collectionPoint.Insert(createCollectionPointDTO);
            return Created("", collectionPoint);
        }
    }
}
