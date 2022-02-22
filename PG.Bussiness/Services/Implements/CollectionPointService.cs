using AutoMapper;
using PG.Bussiness.DTOs;
using PG.Bussiness.DTOs.GetDTOs;
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

        public async Task<PaginateDTO<CollectionPointDTO>> GetByState(int page, int amount, string state)
        {
            var genericResult = await _collectionPointRepository.GetByState(state);
            //var genericResult = await _collectionPointRepository.GetAll();
            List<CollectionPointDTO> genericList = new();
            foreach (var item in genericResult)
            {
                var result = _mapper.Map<CollectionPointDTO>(item);
                genericList.Add(result);
            }
            var paged = PagedList<CollectionPointDTO>.Create(genericList, page, amount);
            PaginateDTO<CollectionPointDTO> paginate = new()
            {
                Page = page,
                Size = paged.Count,
                NumberOfRecords = genericResult.Count,
                Records = paged
            };
            return paginate;
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
