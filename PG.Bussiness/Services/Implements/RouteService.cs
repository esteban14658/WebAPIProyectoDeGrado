using AutoMapper;
using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.DTOs.UpdateDTOs;
using PG.Models.Entitys;
using PG.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPIProyectoDeGrado.DTOs;
using WebAPIProyectoDeGrado.Repositories;
using WebAPIProyectoDeGrado.Services;
using WebAPIProyectoDeGrado.Services.Implements;

namespace PG.Bussiness.Services.Implements
{
    public class RouteService : GenericService<RouteDTO, CreateRouteDTO, Route>, IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        private readonly ICollectionPointService _collectionPointService;
        private readonly IRecyclerRepository _recyclerRepository;

        public RouteService(IRouteRepository routeRepository, IMapper mapper, ICollectionPointService collectionPointService,
                IRecyclerRepository recyclerRepository) : base(routeRepository, mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
            _collectionPointService = collectionPointService;
            _recyclerRepository = recyclerRepository;
        }

        public async Task<RouteDTO> Finalize(RouteDTO dto, int id)
        {
            var isExists = _routeRepository.Exists(id);
            if (isExists == false)
            {
                throw new KeyNotFoundException("Not found");
            }
            DateTime date = DateTime.Now;
            dto.Id = id;
            dto.CollectionPoints = null;
            dto.EndDate = date;
            var route = _mapper.Map<Route>(dto);
            await _routeRepository.Update(route);
            return dto;
        }

        public async override Task<CreateRouteDTO> Insert(CreateRouteDTO dto)
        {
            var existsRecycler = _recyclerRepository.Exists(dto.Recycler);
            if (existsRecycler == false)
            {
                throw new KeyNotFoundException("Not found");
            }
            var send = _mapper.Map<Route>(dto);
            send.StartDate = DateTime.Now;
            await _routeRepository.Insert(send);
            return dto;
        }
    }
}
