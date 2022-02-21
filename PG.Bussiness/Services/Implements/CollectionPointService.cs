using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class CollectionPointService : GenericService<CollectionPointDTO, CreateCollectionPointDTO, CollectionPoint>, ICollectionPointService
    {
        private readonly ICollectionPointRepository _collectionPointRepository;
        private readonly IMapper _mapper;

        public CollectionPointService(ICollectionPointRepository collectionPointRepository,
            IMapper mapper) : base(collectionPointRepository, mapper)
        {
            _collectionPointRepository = collectionPointRepository;
            _mapper = mapper;
        }

        public async override Task<CreateCollectionPointDTO> Insert(CreateCollectionPointDTO dto)
        {
            DateTime date = DateTime.Now;
            dto.CreateDate = date;
            var collectionPoint = _mapper.Map<CollectionPoint>(dto);

            

            await _collectionPointRepository.Insert(collectionPoint);
            return dto;
        }


    }
}
