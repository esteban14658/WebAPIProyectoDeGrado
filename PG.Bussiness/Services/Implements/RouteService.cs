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
    public class RouteService : GenericService<RouteDto, CreateRouteDto, Route>, IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;
        private readonly IRecyclerRepository _recyclerRepository;

        public RouteService(IRouteRepository routeRepository, IMapper mapper, 
                IRecyclerRepository recyclerRepository) : base(routeRepository, mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
            _recyclerRepository = recyclerRepository;
        }

        public async Task AddCommentToRoute(int idRoute, CreateCommentDto dto)
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
            RouteDto dto = new RouteDto
            {
                Id = id,
                CollectionPoints = null,
                EndDate = date
            };
            var route = _mapper.Map<Route>(dto);
            await _routeRepository.Update(route);
            return id;
        }

        public async Task<List<RouteDto>> GetByDate(string date)
        {
            var list = new List<RouteDto>();
            var query = await _routeRepository.GetByDate(date);
            foreach (var item in query)
            {
                var mapped = _mapper.Map<RouteDto>(item);
                list.Add(mapped);
            }
            return list;
        }

        public override async Task<RouteDto> GetById(int id)
        {
            var exists = _routeRepository.Exists(id);
            if (!exists)
            {
                throw new KeyNotFoundException("Route not found");
            }
            var genericResult = await _routeRepository.GetById(id);
            var routeDto = _mapper.Map<RouteDto>(genericResult);
            return routeDto;
        }

        public async Task<List<RouteDto>> GetByIdRecycler(int idRecycler)
        {
            var result = await _routeRepository.GetByIdRecycler(idRecycler);
            var list = new List<RouteDto>();
            foreach (var route in result)
            {
                var mapping = _mapper.Map<RouteDto>(route);
                list.Add(mapping);
            }
            return list;
        }

        public async Task<RouteDto> InsertCustom(CreateRouteDto dto)
        {
            var existsRecycler = _recyclerRepository.Exists(dto.Recycler);
            if (existsRecycler)
            {
                throw new KeyNotFoundException("Not found");
            }
            var activeRoute = _routeRepository.ExistsActiveRoute(dto.Recycler);
            if (activeRoute)
            {
                throw new AppException("The recycler has an active route");
            }
            var send = _mapper.Map<Route>(dto);
            send.StartDate = DateTime.Now.ToUniversalTime().AddHours(-5);
            send.EndDate = null;
            var body = await _routeRepository.Insert(send);
            var getWithId = _mapper.Map<RouteDto>(body);
            return getWithId;
        }
    }
}
