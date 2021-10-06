using AutoMapper;
using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Models.Entitys;
using PG.Models.Repositories;
using WebAPIProyectoDeGrado.Services.Implements;

namespace PG.Bussiness.Services.Implements
{
    public class RouteService : GenericService<RouteDTO, CreateRouteDTO, Route>, IRouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IMapper _mapper;

        public RouteService(IRouteRepository routeRepository, IMapper mapper) : base(routeRepository, mapper)
        {
            _routeRepository = routeRepository;
            _mapper = mapper;
        }
    }
}
