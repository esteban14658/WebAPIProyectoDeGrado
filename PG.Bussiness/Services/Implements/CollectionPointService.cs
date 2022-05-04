using AutoMapper;
using Microsoft.AspNetCore.Http;
using PG.Bussiness.DTOs;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Entitys;
using WebAPIProyectoDeGrado.Repositories;

namespace WebAPIProyectoDeGrado.Services.Implements
{
    public class CollectionPointService : GenericService<CollectionPointDto, CreateCollectionPointDto, CollectionPoint>, ICollectionPointService
    {
        private readonly ICollectionPointRepository _collectionPointRepository;
        private readonly IMapper _mapper;

        public CollectionPointService(ICollectionPointRepository collectionPointRepository,
            IMapper mapper) : base(collectionPointRepository, mapper)
        {
            _collectionPointRepository = collectionPointRepository;
            _mapper = mapper;
        }

        public async Task<PaginateDto<CollectionPointDto>> GetByState(int page, int amount, string state)
        {
            var genericResult = await _collectionPointRepository.GetByState(state);
            return Paginate(genericResult, page, amount);
        }

        public async override Task<CreateCollectionPointDto> Insert(CreateCollectionPointDto dto)
        {
            var collectionPoint = _mapper.Map<CollectionPoint>(dto);
            await _collectionPointRepository.Insert(collectionPoint);
            return dto;
        }

        public override async Task<CollectionPointDto> GetById(int id)
        {
            var isExists = _collectionPointRepository.Exists(id);
            if (isExists == false)
            {
                throw new KeyNotFoundException("The collection point didn´t found");
            }
            var genericResult = await _collectionPointRepository.GetById(id);
            var collectionPointDto = _mapper.Map<CollectionPointDto>(genericResult);
            return collectionPointDto;
        }

        public async Task<PaginateDto<CollectionPointDto>> GetByTypeOfMaterial(int page, int amount, string typeOfMaterial)
        {
            var genericResult = await _collectionPointRepository.GetByTypeOfMaterial(typeOfMaterial);
            return Paginate(genericResult, page, amount);
        }

        public async Task<PaginateDto<CollectionPointDto>> GetByDate(int page, int amount)
        {
            var genericResult = await _collectionPointRepository.GetByDate();
            return Paginate(genericResult, page, amount);
        }

        public async Task<int> AssignToRoute(CollectionPointUpdateDto dto, string stateCompare)
        {
            var isExists = _collectionPointRepository.Exists(dto.Id);
            if (isExists == false)
            {
                throw new KeyNotFoundException("The collection point didn´t found");
            }
            var result = await GetById(dto.Id);
            result.TypeOfMaterial = dto.TypeOfMaterial;
            result.RouteId = dto.RouteId;
            result.State = dto.State;
            var collectionPoint = _mapper.Map<CollectionPoint>(result);
            await _collectionPointRepository.Update(collectionPoint, stateCompare);
            return dto.Id;
        }

        public async Task<PaginateDto<CollectionPointDto>> GetByIdResident(int page, int amount, int idResident, string state)
        {
            var genericResult = await _collectionPointRepository.GetByIdResident(idResident, state);
            return Paginate(genericResult, page, amount);
        }

        private PaginateDto<CollectionPointDto> Paginate(List<CollectionPoint> list, int page, int amount)
        {
            List<CollectionPointDto> genericList = new();
            foreach (var item in list)
            {
                var result = _mapper.Map<CollectionPointDto>(item);
                genericList.Add(result);
            }
            var paged = PagedList<CollectionPointDto>.Create(genericList, page, amount);
            PaginateDto<CollectionPointDto> paginate = new()
            {
                Page = page,
                Size = paged.Count,
                NumberOfRecords = list.Count,
                Records = paged
            };
            return paginate;
        }

        public IFormFile Base64ToIFormFile(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(base64String);
            MemoryStream stream = new MemoryStream(imageBytes);

            // Convert byte[] to Image
            IFormFile file = new FormFile(stream, 0, imageBytes.Length, "", "");
            return file;
        }

        public async Task<PaginateDto<CollectionPointDto>> GetByStateAndType(int page, int amount, string state, string type)
        {
            var genericResult = await _collectionPointRepository.GetByStateAndType(state, type);
            return Paginate(genericResult, page, amount);
        }

        public async Task<PaginateDto<CollectionPointDto>> GetByIdRoute(int page, int amount, int idRoute, string state)
        {
            var genericResult = await _collectionPointRepository.GetByIdRoute(idRoute, state);
            return Paginate(genericResult, page, amount);
        }
    }
}
