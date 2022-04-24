using AutoMapper;
using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.Exceptions;
using PG.Models.Entitys;
using PG.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task AddCommentToRoute(int idRoute, CreateCommentDTO dto)
        {
            var comment = _mapper.Map<Comment>(dto);
            var result = await _routeRepository.AddCommentToRoute(idRoute, comment);
            if (result == null)
            {
                throw new CustomConflictException("The store user already has an address assigned");
            }
        }

        public async Task<int> Finalize(int id)
        {
            var isExists = _routeRepository.Exists(id);
            if (isExists == false)
            {
                throw new KeyNotFoundException("Not found");
            }
            DateTime date = DateTime.Now.ToUniversalTime().AddHours(-5);
            RouteDTO dto = new RouteDTO
            {
                Id = id,
                CollectionPoints = null,
                EndDate = date
            };
            var route = _mapper.Map<Route>(dto);
            await _routeRepository.Update(route);
            return id;
        }

        public override async Task<RouteDTO> GetById(int id)
        {
            var exists = _routeRepository.Exists(id);
            if (!exists)
            {
                throw new KeyNotFoundException("Route not found");
            }
            var genericResult = await _routeRepository.GetById(id);
            var routeDto = _mapper.Map<RouteDTO>(genericResult);
            return routeDto;
        }

        public async Task<List<RouteDTO>> GetByIdRecycler(int idRecycler)
        {
            var result = await _routeRepository.GetByIdRecycler(idRecycler);
            var list = new List<RouteDTO>();
            foreach (var route in result)
            {
                var mapping = _mapper.Map<RouteDTO>(route);
                list.Add(mapping);
            }
            return list;
        }

        public async Task<RouteDTO> InsertCustom(CreateRouteDTO dto)
        {
            var existsRecycler = _recyclerRepository.Exists(dto.Recycler);
            if (existsRecycler == false)
            {
                throw new KeyNotFoundException("Not found");
            }
            var activeRoute = _routeRepository.ExistsActiveRoute(dto.Recycler);
            if (activeRoute == true)
            {
                throw new AppException("The recycler has an active route");
            }
            var send = _mapper.Map<Route>(dto);
            send.StartDate = DateTime.Now.ToUniversalTime().AddHours(-5);
            send.EndDate = null;
            var body = await _routeRepository.Insert(send);
            var getWithId = _mapper.Map<RouteDTO>(body);
            return getWithId;
        }
    }
}
