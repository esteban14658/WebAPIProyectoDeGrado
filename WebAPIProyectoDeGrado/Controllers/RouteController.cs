using Microsoft.AspNetCore.Mvc;
using PG.Bussiness.DTOs;
using PG.Bussiness.DTOs.CreateDTOs;
using PG.Bussiness.DTOs.GetDTOs;
using PG.Bussiness.Services;
using System.Threading.Tasks;

namespace PG.Presentation.Controllers
{
    [ApiController]
    [Route("api/Routes")]
    public class RouteController: ControllerBase
    {
        private readonly IRouteService _routeService;

        public RouteController(IRouteService routeService)
        {
            _routeService = routeService;
        }

        [HttpGet("{page:int}/{amount:int}")]
        public async Task<ActionResult<PaginateDTO<RouteDTO>>> Get(int page, int amount)
        {
            var route = await _routeService.GetAll(page, amount);
            return Ok(route);
        }

        [HttpPut("{id:int}")]
        public async Task<ActionResult<int>> Finalize(RouteDTO dto, int id)
        {
            var route = await _routeService.Finalize(dto, id);
            return Accepted(route.Id);
        }

        [HttpPost]
        public async Task<ActionResult> Post(CreateRouteDTO dto)
        {
            await _routeService.Insert(dto);
            return Created("", dto);
        }
    }
}
